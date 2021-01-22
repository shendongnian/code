    public class MyComparer : IComparer<string>
    {
        public int Compare(string stringA, string stringB)
        {
            string small = stringA;
            string big = stringB;
            if (stringA.Length > stringB.Length)
            {
                small = stringB;
                big = stringA;
            }
            else if (stringA.Length < stringB.Length)
            {
                small = stringA;
                big = stringB;
            }
            for (int j = 0; j < small.Length; j++)
            {
                if (Convert.ToInt32(small[j]) > Convert.ToInt32(big[j])) return -1;
                if (Convert.ToInt32(small[j]) < Convert.ToInt32(big[j])) return 1;
            }
            //big is indeed bigger
            if (big.Length > small.Length) return 1;
            //finally they are smae
            return 0;
        }
    }
