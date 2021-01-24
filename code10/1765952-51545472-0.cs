        static void Main()
        {
            List<StudyAreasClass> areas = new List<StudyAreasClass>();
            areas.Add(new StudyAreasClass() { Name = "A", Students = 5, Department = "D1" });
            areas.Add(new StudyAreasClass() { Name = "B", Students = 1, Department = "D1" });
            areas.Add(new StudyAreasClass() { Name = "C", Students = 2, Department = "D2" });
            areas.Add(new StudyAreasClass() { Name = "D", Students = 10, Department = "D3" });
            var sortedList =
                from area in areas
                join sub in (from a in areas
                             group a by a.Department into g
                             select new
                             {
                                 Department = g.Key,
                                 StudentCount = g.Sum(x => x.Students)
                             }) on area.Department equals sub.Department
                orderby sub.StudentCount, area.Students
                select area;
            foreach (var area in sortedList)
                Console.WriteLine(area.Name);
            //C, B, A, D
        }
