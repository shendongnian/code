    struct INDI
            {
                public string ID;
                public string Name;
                public string Sex;
                public string BirthDay;
                public bool Dead;
        
        
            }
            struct FAM
            {
                public string FamID;
                public string type;
                public string IndiID;
            }
            List<INDI> Individuals = new List<INDI>();
            List<FAM> Family = new List<FAM>();
            private void button1_Click(object sender, EventArgs e)
            {
                string path = @"C:\mostrecent.ged";
                ParseGedcom(path);
            }
        
            private void ParseGedcom(string path)
            {
                //Open path to GED file
                StreamReader SR = new StreamReader(path);
                
                //Read entire block and then plit on 0 @ for individuals and familys (no other info is needed for this instance)
                string[] Holder = SR.ReadToEnd().Replace("0 @", "\u0646").Split('\u0646');
        
                //For each new cell in the holder array look for Individuals and familys
                foreach (string Node in Holder)
                {
        
                    //Sub Split the string on the returns to get a true block of info
                    string[] SubNode = Node.Replace("\r\n", "\r").Split('\r');
                    //If a individual is found
                    if (SubNode[0].Contains("INDI"))
                    {
                        //Create new Structure
                        INDI I = new INDI();
                        //Add the ID number and remove extra formating
                        I.ID = SubNode[0].Replace("@", "").Replace(" INDI", "").Trim();
                        //Find the name remove extra formating for last name
                        I.Name = SubNode[FindIndexinArray(SubNode, "NAME")].Replace("1 NAME", "").Replace("/", "").Trim(); 
                        //Find Sex and remove extra formating
                        I.Sex = SubNode[FindIndexinArray(SubNode, "SEX")].Replace("1 SEX ", "").Trim();
        
                        //Deterine if there is a brithday -1 means no
                        if (FindIndexinArray(SubNode, "1 BIRT ") != -1)
                        {
                            // add birthday to Struct 
                            I.BirthDay = SubNode[FindIndexinArray(SubNode, "1 BIRT ") + 1].Replace("2 DATE ", "").Trim();
                        }
        
                        // deterimin if there is a death tag will return -1 if not found
                        if (FindIndexinArray(SubNode, "1 DEAT ") != -1)
                        {
                            //convert Y or N to true or false ( defaults to False so no need to change unless Y is found.
                            if (SubNode[FindIndexinArray(SubNode, "1 DEAT ")].Replace("1 DEAT ", "").Trim() == "Y")
                            {
                                //set death
                                I.Dead = true;
                            }
                        }
                        //add the Struct to the list for later use
                        Individuals.Add(I);
                    }
        
                    // Start Family section
                    else if (SubNode[0].Contains("FAM"))
                    {
                        //grab Fam id from node early on to keep from doing it over and over
                        string FamID = SubNode[0].Replace("@ FAM", "");
        
                        // Multiple children can exist for each family so this section had to be a bit more dynaimic
                        
                        // Look at each line of node
                        foreach (string Line in SubNode)
                        {
                            // If node is HUSB
                            if (Line.Contains("1 HUSB "))
                            {
                                
                                FAM F = new FAM();
                                F.FamID = FamID;
                                F.type = "PAR";
                                F.IndiID = Line.Replace("1 HUSB ", "").Replace("@","").Trim();
                                Family.Add(F);
                            }
                                //If node for Wife
                            else if (Line.Contains("1 WIFE "))
                            {
                                FAM F = new FAM();
                                F.FamID = FamID;
                                F.type = "PAR";
                                F.IndiID = Line.Replace("1 WIFE ", "").Replace("@", "").Trim();
                                Family.Add(F);
                            }
                                //if node for multi children
                            else if (Line.Contains("1 CHIL "))
                            {
                                FAM F = new FAM();
                                 F.FamID = FamID;
                                F.type = "CHIL";
                                F.IndiID = Line.Replace("1 CHIL ", "").Replace("@", "");
                                Family.Add(F);
                            }
                        }
                    }
                }
            }
        
            private int FindIndexinArray(string[] Arr, string search)
            {
                int Val = -1;
                for (int i = 0; i < Arr.Length; i++)
                {
                    if (Arr[i].Contains(search))
                    {
                        Val = i;
                    }
                }
                return Val;
            }
