        enum quotestatus
        {
            none,
            firstquote,
            secondquote
        }
        public static System.Collections.ArrayList Parse(string line,string delimiter)
        {        
            System.Collections.ArrayList ar = new System.Collections.ArrayList();
            StringBuilder field = new StringBuilder();
            quotestatus status = quotestatus.none;
            foreach (char ch in line.ToCharArray())
            {                                
                string chOmsch = "char";
                if (ch == Convert.ToChar(delimiter))
                {
                    if (status== quotestatus.firstquote)
                    {
                        chOmsch = "char";
                    }                         
                    else
                    {
                        chOmsch = "delimiter";                    
                    }                    
                }
                if (ch == Convert.ToChar(34))
                {
                    chOmsch = "quotes";           
                    if (status == quotestatus.firstquote)
                    {
                        status = quotestatus.secondquote;
                    }
                    if (status == quotestatus.none )
                    {
                        status = quotestatus.firstquote;
                    }
                }
                
                switch (chOmsch)
                {
                    case "char":
                        field.Append(ch);
                        break;
                    case "delimiter":                        
                        ar.Add(field.ToString());
                        field.Clear();
                        break;
                    case "quotes":
                        if (status==quotestatus.firstquote)
                        {
                            field.Clear();                            
                        }
                        if (status== quotestatus.secondquote)
                        {                                                                           
                                status =quotestatus.none;                                
                        }                    
                        break;
                }
            }
            if (field.Length != 0)            
            {
                ar.Add(field.ToString());                
            }           
            return ar;
        }
