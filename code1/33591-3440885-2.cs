            Mapper.CreateMap<Student, StudentDTO>();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                StudentDTO dto = Mapper.Map<Student, StudentDTO>(_student);
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                StudentDTO itemT = _student;
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                StudentDTO itemT = new StudentDTO
                {
                    Id = _student.Id,
                    Name = _student.Name,
                };
                itemT.Courses = new List<int>();
                foreach (var course in _student.Courses)
                {
                    itemT.Courses.Add(course);
                }
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
