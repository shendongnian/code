    teachers.SelectMany(t =>
                t.StudentNames.Select(s => new TeacherStudent
                {
                    TeacherId = t.TeacherId,
                    TeacherName = t.TeacherName,
                    StudentName = s
                }));
