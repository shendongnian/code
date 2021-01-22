    var adaptationsUnsorted = from aun in dbContext.Adaptations
                              where aun.EventID == iep.EventID
                              select new Adaptation
                              {
                                  StudentID = aun.StudentID,
                                  EventID = aun.EventID,
                                  Name = aun.Name,
                                  Value = aun.Value
                              };
    
    var adaptationsSorted = adaptationsUnsorted.ToList<Adaptation>().OrderBy(a => a.Name, new AdaptationComparer ());
    
    foreach (Adaptation adaptation in adaptationsSorted)
    {
        // do real work
    }
    public class AdaptationComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            string x1 = Regex.Replace(x, @"ADAPT([0-9])$", @"ADAPT0$1");
            string y1 = Regex.Replace(y, @"ADAPT([0-9])$", @"ADAPT0$1");
            return Comparer<string>.Default.Compare(x1, y1);
        }
    }
