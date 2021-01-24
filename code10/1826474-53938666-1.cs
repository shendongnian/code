    var list = dataTable.AsEnumerable()
                        .GroupBy(rec => rec.Field<int>("SId"),
                                 (key, gr) => new Student
                                 {
                                     SId = key,
                                     SName = gr.First().Field<string>("SName"),
                                     SDetail = gr.Select(detail => new StudentDetail
                                     {
                                         StudentDetailId = detail.Field<int>("StudentDetailId"),
                                         ExamId = detail.Field<int>("ExamId"),
                                         Department = detail.Field<string>("Department")
                                     }).ToList()
                                  }).ToList();
