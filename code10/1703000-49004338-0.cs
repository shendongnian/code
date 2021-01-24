            public class AwardIndex : Raven.Client.Indexes.AbstractMultiMapIndexCreationTask<AwardIndex.Result>
            {
                public class Result
                {
                    public string AwardeeAwardor { get; set; } //is Awardee or Awardor
                    public string ItemType { get; set; } //DOT, DOJ, PSI, ecc
                    public double Value { get; set; }
                }
    
                public AwardIndex()
                {
                    AddMap<Award>(items => from item in items
                                           select new Result
                                           {
                                               AwardeeAwardor = "Awardee",
                                               ItemType = item.Awardee,
                                               Value = item.Amount
                                           });
    
                    AddMap<Award>(items => from item in items
                                           select new Result
                                           {
                                               AwardeeAwardor = "Awardor",
                                               ItemType = item.Awardor,
                                               Value = item.Amount
                                           });
    
                    Reduce = items => from item in items
                                      group item by new { AwardeeAwardor = item.AwardeeAwardor, ItemType = item.ItemType }
                                      into g
                                      select new Result
                                      {
                                          AwardeeAwardor = g.Key.AwardeeAwardor,
                                          ItemType = g.Key.ItemType,
                                          Value = g.Sum(x => x.Value)
                                      };
                }
            }
