        public class CA
        {
            public CA(string s, dynamic InitValue)
            {
                List<int> InitList = null;
                if (InitValue is List<int>)
                    InitList = InitValue;
                else if (InitValue is int)
                {
                    InitList = new List<int>();
                    InitList.Add(InitValue);
                }
                // Now, InitList contains your list for further initialization,
                //  if the client passed either a List<int> or an int:
                if (InitList != null)
                {
                    // do some initialization
                }
            }
        }
