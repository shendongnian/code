    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication2
    {
        class Competition
        {
            public int CompetitionID;
            public int ParentCompetitionID;
            public List<Competition> Children=new List<Competition>();
            public Competition(int id, int parent_id) 
            { 
                CompetitionID = id; 
                ParentCompetitionID = parent_id; 
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                List<Competition> comps = new List<Competition>()
                {
                    new Competition(1, 0), 
                    new Competition(2,1),
                    new Competition(3,1),
                    new Competition(4,2),
                    new Competition(5,3)
                };
    
                Dictionary<int, Competition> dic = comps.ToDictionary(e => e.CompetitionID);
                foreach (var c in comps)
                    if (dic.ContainsKey(c.ParentCompetitionID))
                        dic[c.ParentCompetitionID].Children.Add(c);
                var root = dic[1];
            }
        }
    }
