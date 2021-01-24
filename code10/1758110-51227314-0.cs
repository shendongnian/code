     public static int[] xx = { 1, 2, 3, 4, 5, 6, 87, 8, 9, 7, 5, 24, 58, 63, 10, 11, 87, 20, 22, 90, 14, 17, 19, 21, 18, 24 };
            public class MyBinary
            {
                public string BinString { get; set; }
                public int OneCount { get; set; }
                public int OriginalInt { get; set; }
                public MyBinary(string input, int count, int original)
                {
                    OriginalInt = original;
                    BinString = input;
                    OneCount = count;
                }
            }
            
            private List<MyBinary> SortByOnes(int[] input)
            {
                List<MyBinary> lst = new List<MyBinary>();
                //The following will give a result First ordered by number of ones but also 
                // secondarily the original numbers
                //just a bit of linq
                int[] SortedArray = (from i in input orderby i select i).ToArray();
                List <MyBinary> lstSorted = new List<MyBinary>();
                int index = 0;
                string[] Bin = new string[SortedArray.Count()];
                foreach (int i in SortedArray)
                {
                    Bin[index] = Convert.ToString(i, 2);
                     int oneCount = 0;
                    foreach (char c in Bin[index])
                    {
                        if (c == '1')
                            oneCount += 1;
                    }
                    //sends the binary string, the count of ones, and the original number
                    //to the constructor of MyBinary
                    lst.Add(new MyBinary(Bin[index], oneCount, i));
                    lstSorted = (from b in lst orderby b.OneCount descending select b).ToList();
                    index += 1;
                }
                return lstSorted;
            }
           //To use:
            private void TestSort()
            {
                List<MyBinary> lst = SortByOnes(xx);
                foreach (MyBinary b in lst)
                { Debug.Print($"{b.OneCount}  -  {b.BinString}  -  {b.OriginalInt}"); }
            }
