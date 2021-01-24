     var students = Enumerable.Range(1, 21).ToArray();
     var groups = new List<int[]>();
    
     foreach(var s1 in students)
         foreach(var s2 in students.Where(s => s > s1))
            foreach(var s3 in students.Where(s => s > s2))
            {
                int[] a = { s1, s2, s3 };
    
                bool allowed = true;
    
                foreach(var g in groups)
                {
                   if (g.Contains(s1) && (g.Contains(s2) || g.Contains(s3)) ||
                       g.Contains(s2) && g.Contains(s3))
                   {
                       allowed = false;
                       break;
                   }
                }
    
                if (allowed)
                {
                    groups.Add(a);
                }
            }
     Console.WriteLine($"groups: {groups.Count}");
