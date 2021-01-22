    arr.Aggregate(
        new { MinDate = DateTime.MaxValue,
              MaxDate = DateTime.MaxValue },
        (accDates, record) => 
            new { MinDate = record.Date < accDates.MinDate 
                            ?  record.Date 
                            : accDates.MinDate,
                  MaxDate = accDates.MaxDate < record.Date 
                            ?  record.Date 
                            : accDates.MaxDate });
