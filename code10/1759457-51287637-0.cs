      var total = appointments
        .OrderBy(appointment => appointment.StartDate)
        .Aggregate(new Tuple<double, DateTime?>(0.0, null), (acc, item) => {
          if (!acc.Item2.HasValue || acc.Item2.Value <= item.StartDate) // Disjoint
            return new Tuple<double, DateTime?>(
              acc.Item1 + (item.FinishDate - item.StartDate).TotalHours, 
              item.FinishDate);
          else if (acc.Item2.Value >= item.FinishDate) // Include
            return acc;
          else // Partially overlap
            return new Tuple<double, DateTime?>(
              acc.Item1 + (item.FinishDate - acc.Item2.Value).TotalHours,
              item.FinishDate);
        })
        .Item1;
     // 8
     Console.WriteLine(total);
