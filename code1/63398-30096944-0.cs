    public class MyComparer : IComparer<string>
    {
        public int Compare(string stringA, string stringB)
        {
            if (stringA.Length > stringB.Length) return -1;
            if (stringA.Length < stringB.Length) return 1;
            char[] valueA = stringA.ToArray();
            char[] valueB = stringB.ToArray();
            for (int j = 0; j < valueA.Length; j++)
            {
                if (Convert.ToInt32(valueA[j]) > Convert.ToInt32(valueB[j])) return -1;
                if (Convert.ToInt32(valueA[j]) < Convert.ToInt32(valueB[j])) return 1;
            }
            return 0;
        }
    }
