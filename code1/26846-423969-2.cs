           System.Text.RegularExpressions.MatchCollection  matchCol;
           System.Text.RegularExpressions.Regex regX = new System.Text.RegularExpressions.Regex("(?=AA)");
            string index="";            
            string str="BAAABBB";
            matchCol = regX.Matches("BAAABBB");
            foreach (System.Text.RegularExpressions.Match mat in matchCol)
                {
                    index = index + mat.Index + ",";
                }                       
              
