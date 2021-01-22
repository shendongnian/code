        struct Summary 
        {
          public DateTime DateBegin {get; set;}
          public DateTime DateEnd {get; set;}
          public int Income  {get; set;}
          public int ExpenditureBank {get; set;}
          public int ExpenditureClient {get; set;}
          public int Expenditure {get {return ExpenditureBank+ExpenditureClient; }}
        }
    
    void Summarize(IEnumerable<Sections> sections)
    {
     var result = sections.Aggregate(new Summary
     {
      DateBegin = DateTime.MaxValue,
      DateEnd = DateTime.MinValue,
      Income = 0,
      ExpenditureBank =0,
      ExpenditureClient =0,
     },
      (agg, next) =>
      new Summary
      {
       DateBegin = next.Date < agg.DateBegin ? next.Date : agg.DateBegin,
       DateEnd = next.Date > agg.DateEnd ? next.Date : agg.DateEnd,
       Income = agg.Income + (next.IsIncome ? next.Amount : 0),
       ExpenditureBank = next.IsExpenditureBank ? next.Amount: 0,
       ExpenditureClient = next.IsExpenditureClient ? next.Amount : 0
      }
     );
    }
