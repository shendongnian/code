        private static IEnumerable<int> GetNumbers(string str)
        {
            foreach (var st in str.Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries)
                .Where(s => (s.ToCharArray()
                    .All(c => Char.IsDigit(c)))))
            {
                yield return Convert.ToInt32(st);
            }
        }
