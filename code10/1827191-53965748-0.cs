    Dictionary<UInt64, List<StudentDetail>> StudentDetailList
     = dataTable.AsEnumerable()
      .GroupBy(row => new UInt64(       
          (UInt64)(row.Field<int>("StudentId"))<< 32 |
          (UInt64)(row.Field<int>("StudentTempId"));
       )).
       ToDictionary
       (
          dict => dict.Key,
          dict => dict.Select(row => new StudentDetail
          {
             Department = row.Field<string>("Department"),
             Address = row.Field<string>("Address"),
             TotalMarks = row.Field<int>("TotalMarks")
          }).ToList()
        );
