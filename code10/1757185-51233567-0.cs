    string mystring = "Display(String type1)";
                string mystringValue = @"'1'";
    
                string s = mystring.Replace("String", string.Empty).Replace(")", string.Empty).Replace('(', ',');
                string[] s2 = s.Split(',');
    
                ArrayList myArrayList = new ArrayList(s2);           
                myArrayList.RemoveAt(0);
    
                string[] s3 = mystringValue.Split(',');
    
                List<PropertyInformation> list = new List<PropertyInformation>();
                int index = 0;
                foreach (string name in myArrayList)
                {
                    PropertyInformation p = new PropertyInformation();
                    p.Name = name;
                    p.Value = s3[index];
                    list.Add(p);
                    index++;
                }
