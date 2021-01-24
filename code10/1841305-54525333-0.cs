    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>() {
                -2962   ,
                -5787   ,
                -1671   ,
                -5667   ,
                -498    ,
                -4463   ,
                1399    ,
                3608    ,
                2173    ,
            };
            int index = list.FindIndex((x) => x>0)-1;
            // index = 5
            index=list.Zip(list.Skip(1), (x, y) => Math.Sign(x*y)).ToList().FindIndex((s) => s==-1);
            // index = 5
        }
    }
