    void Summarize(IEnumerable<Section> sections)
    {
        this.DateBegin = sections.Select(s => s.Date).Min();
        this.DateEnd = sections.Select(s => s.Date).Max();
        this.Income = sections.Where(s => s.IsIncome).Sum(r => r.Amount);
        this.Expenditure = sections.Aggregate(0, (agg, next) => 
            agg += (next.IsExpenditureBank ? next.Amount : 0) +
                (next.IsExpenditureClient ? next.Amount : 0));
    }
