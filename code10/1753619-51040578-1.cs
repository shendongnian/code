    static IEnumerable<XZ[]> SplitByZGap(IEnumerable<XZ> points, int gap)
    {
        var group = new List<XZ>();
        bool first = true;
        int lastZ = 0;
        foreach (var point in points)
        {
            if (first)
            {
                first = false;
            }
            else if (Math.Abs(point.Z - lastZ) >= gap)
            {
                var group2 = group.ToArray();
                group.Clear();
                yield return group2;
            }
            lastZ = point.Z;
            group.Add(point);
        }
        {
            var group2 = group.ToArray();
            group.Clear();
            yield return group2;
        }
    }
