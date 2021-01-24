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
                group area by area.Department into g2
                select g2;
                
                
            foreach (var departmentList in sortedList)
            {
                Console.WriteLine(departmentList.Key);
                foreach (var area in departmentList)
                    Console.WriteLine(area.Name);
            }
            //D2
            //C
            //D1
            //B
            //A
            //D3
            //D
        }
