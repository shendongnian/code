        static void Main(string[] args)
        {
            var arrays = new List<string[]>();
            var arr1 = new string[] { "A", "B", "C" };
            var arr2 = new string[] { "D", "E", "F" };
            var arr3 = new string[] { "G", "H", "I" };
            arrays.Add(arr1);
            arrays.Add(arr2);
            arrays.Add(arr3);
            
            IEnumerable<Tuple<string,string>> oQuery1 = null;
            int count = arrays.Count;
            var k = arrays[0].AsEnumerable();
            for (int i =1; i< count; i++)
            {
                var l1 = arrays[i];
                oQuery1 =  k.SelectMany((x) => l1, (x, y) => Tuple.Create( x, y ));
                k = oQuery1.Select(x=>x.ToString());
            }
    }
