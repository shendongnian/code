            private static List<Tuple<int, int>> Insert(List<Tuple<int, int>> ranges, int startIndex, int endIndex)
            {
                if (ranges == null || ranges.Count == 0)
                    return new List<Tuple<int, int>> { new Tuple<int, int>(startIndex, endIndex) };
                var newIndex = ranges.Count;
                for (var i = 0; i < ranges.Count; i++)
                {
                    if (ranges[i].Item1 > startIndex)
                    {
                        newIndex = i;
                        break;
                    }
                }
                var min = ranges[0].Item1;
                var max = ranges[0].Item2;
                var newRanges = new List<Tuple<int, int>>();
                for (var i = 0; i <= ranges.Count; i++)
                {
                    int rangeStart;
                    int rangeEnd;
                    if (i == newIndex)
                    {
                        rangeStart = startIndex;
                        rangeEnd = endIndex;
                    }
                    else
                    {
                        var range = ranges[i > newIndex ? i - 1 : i];
                        rangeStart = range.Item1;
                        rangeEnd = range.Item2;
                    }
                    if (rangeStart > max && rangeEnd > max)
                    {
                        newRanges.Add(new Tuple<int, int>(min, max));
                        min = rangeStart;
                    }
                    max = rangeEnd > max ? rangeEnd : max;
                }
                newRanges.Add(new Tuple<int, int>(min, max));
                return newRanges;
            }
