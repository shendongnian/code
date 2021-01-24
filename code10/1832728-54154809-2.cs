    static void Main(string[] args)
        {
            int[] number = { 50, 40, 30, 30, 25, 25 };
            int bound = 100;
            var numbers = new List<dynamic>();
            Random rnd = new Random();
            var ans_collection = new List<List<List<int>>>();
            //number of random answers , best answer depends on i so you can't be sure this algorithm always finds optimal answer choose i big enough...
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < number.Length; j++)
                {
                    numbers.Add(new { num = number[j], seen = false });
                }
                var ans = new List<List<int>>();
                var container = new List<int>();
                var distSum = 0;
                //while loop generates a distribution
                while (numbers.Where(x => !x.seen).Count() > 0)
                {
                    var choosen = numbers.OrderBy(x => rnd.NextDouble()).Where(x => !x.seen && distSum + x.num <= bound).FirstOrDefault();
                    if (numbers.Where(x => !x.seen && distSum + x.num <= bound).Count() > 0)
                    {
                        container.Add(choosen.num);
                        distSum += choosen.num;
                        numbers.Add(new { num = choosen.num, seen = true });
                        numbers.Remove(choosen);
                        if (numbers.Where(x => !x.seen && distSum + x.num <= bound).Count() == 0)
                        {
                            ans.Add(new List<int>(container));
                            container = new List<int>();
                            distSum = 0;
                        }
                    }
                    else
                    {
                        ans.Add(new List<int>(container));
                        container = new List<int>();
                        distSum = 0;
                    }
                }
                ans_collection.Add(new List<List<int>>(ans));
            }
            //find best answer based on sum of *unused* amounts
            var min = ans_collection.Min(ans => ans.Sum(dis => (bound - dis.Sum())));
            var best = ans_collection.Where(ans => ans.Sum(dis => (bound - dis.Sum())) == min).FirstOrDefault();
            best.ForEach(x => Console.WriteLine(string.Join(",", x.Select(Y => Y.ToString()))));
        }
