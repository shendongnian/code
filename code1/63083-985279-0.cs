        static void TimeAction(string description, int times, Action func) {
            var watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < times; i++) {
                func();
            }
            watch.Stop();
            Console.Write(description);
            Console.WriteLine(" Time Elapsed {0} ms", watch.ElapsedMilliseconds);
        } 
        static void Main(string[] args) {
            var array = Enumerable.Range(0, 10000000).ToArray();
            var list = Enumerable.Range(0, 10000000).ToArray().ToList();
            // jit
            TimeAction("Ignore and jit", 1 ,() =>
            {
                var junk = array.Length;
                var junk2 = list.Count;
                array.Count();
                list.Count();
            });
            TimeAction("Array Length", 1000000, () => {
                var tmp1 = array.Length;
            });
            TimeAction("Array Count()", 1000000, () =>
            {
                var tmp2 = array.Count();
            });
            TimeAction("Array Length through cast", 1000000, () =>
            {
                var tmp3 = (array as ICollection<int>).Count;
            });
            TimeAction("List Count", 1000000, () =>
            {
                var tmp1 = list.Count;
            });
            TimeAction("List Count()", 1000000, () =>
            {
                var tmp2 = list.Count();
            });
            Console.ReadKey();
        }
