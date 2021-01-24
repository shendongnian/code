        private static Dictionary<int, List<string>> Transform(Dictionary<string, int> input)
        {
            var result = new Dictionary<int, List<string>>();
            foreach (var value in input.Select(x => x.Value).Distinct())
            {
                var lst = input.Where(x => x.Value == value).Select(x => x.Key).ToList();
                result.Add(value, lst);
            }
            return result;
        }
