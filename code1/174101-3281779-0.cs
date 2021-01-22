     const int SIZE = 10;
        static void Main(string[] args)
        {
            List<int> list = new List<int>(SIZE);
            for(int i=0;i<SIZE;i++)
            {
                list.Add(i);
            }
            Parallel.ForEach(GetCombinations(list),(t,state,l)=>
                Console.WriteLine("{0},{1},{2}",l,t.Item1,t.Item2));
        }
        static IEnumerable<Tuple<int,int>> GetCombinations(List<int> list)
        {
            for(int i=0;i<list.Count;i++)
                for(int j=0;j<list.Count;j++)
                    yield return Tuple.Create(list[i],list[j]);
        }
