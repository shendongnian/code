    var result = strings.Aggregate(new Dictionary<string, Object>(), (acc, s) =>
    {
        Dictionary<string, Object> previousLevel = null;
        Dictionary<string, Object> nextLevel = acc;
        string previousSegment = null;
        foreach (string nextSegment in s.Split('.'))
        {
            if (Int16.TryParse(nextSegment, out _))
            {
                if (previousLevel[previousSegment] is Dictionary<string, Object>)
                {
                    previousLevel[previousSegment] = new List<string>();
                }
                var list = previousLevel[previousSegment] as List<string>;
                list.Add(nextSegment);
            }
            else
            {
                if (!nextLevel.ContainsKey(nextSegment))
                {
                    var child = new Dictionary<string, Object>();
                    nextLevel.Add(nextSegment, child);
                }
                previousSegment = nextSegment;
                previousLevel = nextLevel;
                nextLevel = nextLevel[nextSegment] as Dictionary<string, Object>;
            }
        }
        return acc;
    });
