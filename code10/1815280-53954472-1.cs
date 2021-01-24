        public class Data
        {
            public int Id { get; set; }
            public int? ParentId { get; set; }
        }
        
        static List<Data> elements = new List<Data>();
        static void Main(string[] args)
        {
            //To fill up the list with huge number if items
            elements.Add(new Data() { Id = 1, ParentId = null });
            Enumerable.Range(2, 1000000).ToList().ForEach(x => elements.Add(new Data { Id = x, ParentId = x - 1 }));
            //Making dictionary as you did it
            var parents =elements.ToDictionary(x => x.Id, x => x.ParentId);
            /*Non-Recursive Approach*/
            IEnumerable<int?> GetNonRecursiveParents(int i)
            {
                List<int?> parentsList = new List<int?>();
                if (parents.ContainsKey(i))
                {
                    var parentNode = parents[i];
                    do
                    {
                        parentsList.Add(parentNode);
                        parentNode = parents[parentNode.Value];                        
                    }
                    while (parentNode != null);
                }
                return parentsList;
            };
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var r = GetNonRecursiveParents(7000);
            stopwatch.Stop();
            var elapsed1 = stopwatch.Elapsed;// Execution time: 00:00:00.0023625
            //Making dictionary as you did it
            parents = elements.Where(x => x.ParentId != null).ToDictionary(x => x.Id, x => x.ParentId);
            /*Recursive Approach*/
            IEnumerable<int?> GetParents(int i) =>
                parents.ContainsKey(i)
                    ? new[] { parents[i] }.Concat(GetParents(parents[i].Value))
                    : Enumerable.Empty<int?>();
            stopwatch.Restart();
            var result = GetParents(7000); 
            stopwatch.Stop();
            var elapsed2= stopwatch.Elapsed;// Execution time: 00:00:00.0040636
        }
