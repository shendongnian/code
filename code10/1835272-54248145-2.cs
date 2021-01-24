      var query = from student in students
                orderby student.ExamDate
                group student.Result by student.Test into g
                select new
                {
                    Group = g.Key,
                    Elements = g.OrderByDescending(p2 => p2)
                };
