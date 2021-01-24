      var travel = new List<Travel>
      {
          new Travel("Egypt", new DateTime(2017, 8, 4), new DateTime(2017, 8, 24) ),
          new Travel("Spain", new DateTime(2017, 9, 1), new DateTime(2017, 10, 1) ),
          new Travel("Detroit", new DateTime(2017,9, 15), new DateTime(2017, 9, 20) ),
      };
      var sumOfDates = travel.Sum(t => (t.EndDate - t.StartDate).Days);
