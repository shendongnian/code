    namespace Solutions
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
    
        public class Security
        {
            public Guid Id { get; set; }
    
            public string Name { get; set; }
    
            public string Quatation { get; set; }
    
            //public SecurityType SecurityType { get; set; }
    
            public double Denomination { get; set; }
    
            //public CurrencyType DemoniationType { get; set; }
    
            public virtual ICollection<ReportPeriod> ReportPeriods { get; set; }
        }
    
        public class ReportPeriod
        {
            public Guid Id { get; set; }
    
            public DateTime Start { get; set; }
    
            public DateTime End { get; set; }
    
            public Guid SecurityId { get; set; }
    
            public Guid StockExchangeId { get; set; }
    
            public double Amount { get; set; }
    
            public virtual Security Security { get; set; }
        }
    
        public class Entities
        {
            public static void Main(string[] args)
            {
    
                Security security = new Security()
                {
                    Id = Guid.NewGuid(),
                    Denomination = 1,
                    Name = "A",
                    Quatation = "Z",
                    ReportPeriods = new List<ReportPeriod>()
                };
                security.ReportPeriods.Add(new ReportPeriod()
                {
                    Amount = 10,
                    Security = security,
                    SecurityId = security.Id,
                    End = DateTime.Now.AddDays(1),
                    Start = DateTime.Now,
                    Id = Guid.NewGuid(),
                    StockExchangeId = Guid.NewGuid()
                });
                security.ReportPeriods.Add(new ReportPeriod()
                {
                    Amount = 5,
                    Security = security,
                    SecurityId = security.Id,
                    End = DateTime.Now.AddDays(1),
                    Start = DateTime.Now,
                    Id = Guid.NewGuid(),
                    StockExchangeId = Guid.NewGuid()
                });
                security.ReportPeriods.Add(new ReportPeriod()
                {
                    Amount = 5,
                    Security = security,
                    SecurityId = security.Id,
                    End = DateTime.Now.AddDays(1),
                    Start = DateTime.Now.AddMonths(-1),
                    Id = Guid.NewGuid(),
                    StockExchangeId = Guid.NewGuid()
                });
    
                foreach (var groupedReportValues in security.ReportPeriods
                    .GroupBy(period => new { period.Start.Year, period.Start.Month }).Select(
                        groupedOnMonth => new
                        {
                            StartYear = groupedOnMonth.Key.Year,
                            StartMonth = groupedOnMonth.Key.Month,
                            AmountSum = groupedOnMonth.Sum(reportValue => reportValue.Amount)
                        }))
                {
                    Console.WriteLine(groupedReportValues.StartYear);
                    Console.WriteLine(groupedReportValues.StartMonth);
                    Console.WriteLine(groupedReportValues.AmountSum);
                    Console.WriteLine();
                }
    
                Console.ReadLine();
            }
        }
    }
