       List<Student> studentModelList = new List<Student>();
            for (int i = 1; i <= 60; i++)
            {
                studentModelList.Add(new Student()
                {
                    Name = "Student" + i,
                    RollNo = i
                });
            }
            ReportDataSource Part1DataSource = new ReportDataSource();
            Part1DataSource.Name = "Part1"; // Name of the DataSet we set in .rdlc
            Part1DataSource.Value = studentModelList.Take(studentModelList.Count/2);
            ReportDataSource Part2DataSource = new ReportDataSource();
            Part2DataSource.Name = "Part2"; // Name of the DataSet we set in .rdlc
            Part2DataSource.Value = studentModelList.Skip(studentModelList.Count / 2);
            reportViewer.LocalReport.ReportPath = @"Report4.rdlc"; // Path of the rdlc file
            reportViewer.LocalReport.DataSources.Add(Part1DataSource);
            reportViewer.LocalReport.DataSources.Add(Part2DataSource);
            reportViewer.RefreshReport();
