        public class CA
        {
            public CA(string s, List<int> numList = null, int num = 0)
            {
                // do some initialization
                if (numList == null)
                {
                    numList = new List<int>();
                    numList.Add(num);
                }
            }
        }
