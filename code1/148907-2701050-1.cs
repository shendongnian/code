            List<Range> ranges = new List<Range>();
            ranges.Add(new Range(DateTime.Now, DateTime.Now.AddMonths(3)));
            ranges.Add(new Range(DateTime.Now.AddMonths(3), DateTime.Now.AddMonths(6)));
            Range test = new Range(DateTime.Now.AddMonths(1), DateTime.Now.AddMonths(2));
            var hits = ranges.Where(range => range.Contains(test));
            MessageBox.Show(hits.Count().ToString());
