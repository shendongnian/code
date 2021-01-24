    var groups = Enumerable.Range(7, 6).Concat(Enumerable.Range(1, 6)).GroupJoin(
                items,
                m => m,
                i => i.TransactionDate.Value.Month,
                (m, itemCol) => new { month = m, items = itemCol }); //Create anonymous type with month and items property.
            
        List<string> outputs = new List<string>(); //Contains your output
        int sum = 0;
        foreach (var group in groups) //Iterate the groups
        {
            sum += group.items.Sum(i => i.Amount);
            outputs.Add( //I used string.Format for readability. Does not change functionality
                string.Format("{{ t: \"{0}\", y: {1} }}",
                    new DateTime(group.month > 6 ? 2018 : 2019, group.month, 1).ToString("dd MMM yyyy"),
                    sum));
        }
