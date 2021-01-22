    public class TimeCreatedComparer : IComparer<DictionaryEntry> 
    {
        public int Compare(DictionaryEntry x, DictionaryEntry y)
        {
            var myclass1 = (IMyClass)x.Value;
            var myclass2 = (IMyClass)y.Value;
            return myclass1.TimeCreated.CompareTo(myclass2.TimeCreated);
        }
    }
