    var l = new List<Data>();
    l.Sort(
        (a, b) =>
        {
            var r = a.DateTime.CompareTo(b);
            if (r == 0)
            {
                r = a.Int32.CompareTo(b);
                if (r == 0)
                {
                    r = a.String.CompareTo(b);
                }
            }
            return r;
        }
    );
