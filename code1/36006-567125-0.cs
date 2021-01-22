    //Like ob says, you could create your custom string comparer
    public class MyStringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            // Return -1 if string x should be before string y
            // Return  1 if string x should be after string y
            // Return  0 if string x is the same string as y
        }
    }
