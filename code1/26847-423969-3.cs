           System.Text.RegularExpressions.MatchCollection  matchCol;
           System.Text.RegularExpressions.Regex regX = new System.Text.RegularExpressions.Regex("(?=AA)");
            string index="",str="BAAABBB"; 
            matchCol = regX.Matches(str);
            foreach (System.Text.RegularExpressions.Match mat in matchCol)
                {
                    index = index + mat.Index + ",";
                }                       
              
