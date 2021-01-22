    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Agency
    {
        public string AgencyName { get; set; }
        public int AgencyID { get; set; }
        public IEnumerable<AuditRule> Rules { get; set; } 
        
        public override string ToString()
        {
            return string.Format("Agency {0}/{1}:\r\n{2}",
                AgencyID, AgencyName,
                string.Concat(Rules.Select(x => x.ToString() + "\r\n")
                                   .ToArray()));
        }
    }
    
    public class AuditRule
    {
        public int AuditRuleID { get; set; }
        public string AuditRuleName { get; set; }
        public int AvgDaysWorked { get; set; }
        
        public override string ToString()
        {
            return string.Format("Audit rule {0}/{1}: {2}", AuditRuleID,
                                 AuditRuleName, AvgDaysWorked);
        }
    }
    
    class Test
    {    
        static void Main()
        {
            var previousQuery = new[]
            {
                new { AgencyID = 1, AgencyName = "CCR",
                      AuditRuleName = "Call",  AuditRuleID = 1, DaysWorked = 3 },
                new { AgencyID = 1, AgencyName = "CCR",
                      AuditRuleName = "Call", AuditRuleID = 1, DaysWorked = 5 },
                new { AgencyID = 1, AgencyName = "CCR",
                      AuditRuleName = "Time", AuditRuleID = 2, DaysWorked = 2 },
                new { AgencyID = 2, AgencyName = "YRX",
                      AuditRuleName = "Call", AuditRuleID = 1, DaysWorked = 3 },
                new { AgencyID = 2, AgencyName = "YRX",
                      AuditRuleName = "Acct", AuditRuleID = 3, DaysWorked = 2 },
            };
    
            var itemsGroupedByAgency = previousQuery.GroupBy
                (item => new { item.AgencyID, item.AgencyName });
            
            // Want to do the query for each group
            var query = itemsGroupedByAgency.Select
            // Outdented to avoid scrolling
            (group => new Agency 
             { 
                 AgencyName = group.Key.AgencyName,
                 AgencyID = group.Key.AgencyID,
                 Rules = group.GroupBy(item => new { item.AuditRuleName, 
                                                     item.AuditRuleID },
                                                     (key, items) => new AuditRule
                        // Outdented to avoid scrolling :)
                        {
                           AuditRuleID = key.AuditRuleID,
                           AuditRuleName = key.AuditRuleName,
                           AvgDaysWorked = (int) items.Average(x => x.DaysWorked)
                        })
             });
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }
    }
