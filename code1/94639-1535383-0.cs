            var val = "[[\"9\",\"3\"],[\"8\",\"4\"],[\"7\",\"4\"],[\"6\",\"5\"],[\"5\",\"6\"],[\"4\",\"4\"],[\"3\",\"4\"]]";
            var result = val.ToCharArray()
                .Where(itm => Char.IsDigit(itm))
                .Select((itm, index) => new {c = int.Parse(itm.ToString()),index = index + 1})
                .GroupBy(itm => itm.index % 2 == 0 ? itm.index - 1 : itm.index)
                .Select(itm => new KeyValuePair<int, int>(itm.ElementAt(0).c, itm.ElementAt(1).c));
