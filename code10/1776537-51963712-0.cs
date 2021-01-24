        public class Entity
        {
            public string Text {get; set;}
            public int Index {get; set;}
            
            public int CountDirty {get; set;}
            
            public int CountClean {get; set;}
            public int CountGross {get; set;}
            
            public int IndexStart {get; set;}
            public int IndexEnd {get; set;}
            
            public int IndexStartClean {get; set;}
            public int IndexEndClean {get; set;}
            
            public int IndexStartGross {get; set;}
            public int IndexEndGross {get; set;}
            
            public int CountBefore {get;set;}
            public int CountAfter {get;set;}
        }
        public static List<Entity> findIndices(string text)
        {
            string regex = @"(\[[a-zA-Z]*\])(.*?)(\[/[[a-zA-Z]*\])";
            Regex r = new Regex(regex);
            
            MatchCollection matches = r.Matches(text);
            
            List<Entity> list = new List<Entity>();
            
            int accumulation = 0;
            foreach (Match match in matches)
            {
                Entity t = new Entity();
                
                string stringa2 = match.ToString();
                
                t.CountBefore = match.Groups[1].ToString().Count();
                t.CountAfter = match.Groups[3].ToString().Count();
                
                t.CountClean = match.Groups[2].ToString().Count();
                t.CountGross = match.ToString().Count();
                t.CountDirty = t.CountClean - t.CountGross;
                t.Text = stringa2;
                t.IndexStart = match.Index;
                t.IndexEnd = match.Index + t.CountGross - 1;
                
                t.IndexStartGross = t.IndexStart + t.CountBefore;
                t.IndexEndGross = t.IndexStartGross + t.CountClean - 1;
                
                t.IndexStartClean = t.IndexStartGross - t.CountBefore - accumulation;
                t.IndexEndClean = t.IndexStartClean + t.CountClean - 1;
                
                list.Add(t);
                
                accumulation += t.CountBefore + t.CountAfter;
            }
            
            return list;
        }
