    var studentDetails = dataTable.AsEnumerable()
                .GroupBy(row =>
                (
                    row.Field<int>("StudentId"),
                    row.Field<int>("StudentTempId")
                )).Select(g => g.Select(row => new StudentDetail
                {
                    StudentId = g.Key.Item1,
                    StudentTempId = g.Key.Item2,
                    Department = row.Field<string>("Department"),
                    Address = row.Field<string>("Address"),
                    TotalMarks = row.Field<int>("TotalMarks")
                })).ToList();
