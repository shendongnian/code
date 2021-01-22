        public static List<List<string>> CrossProduct(List<List<string>> s)
        {
            if (!s.Any())
                return new List<List<string>>();
            var c1 = s.First();
            var cRest = s.Skip(1).ToList();
            var sss = from v1 in c1
                      from vRest in CrossProduct(cRest)
                      select (new[] { v1 }.Concat(vRest)).ToList();
            var r = sss.ToList();
            return r;
        }
