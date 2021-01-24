    private static void Main()
        {
            List<int> i=null;
            CheckList(out i,i);
            Console.WriteLine(i[0]);
        }
        public static void CheckList(out List<int> list,List<int> sameList)
        {
            list = sameList;
            if(list==null)
            {
                //Intialize
                list = new List<int>();
                list.Add(1);
            }
            else
            {
                //append
                list.Add(12);
            }
            //Rest of the code
        }
