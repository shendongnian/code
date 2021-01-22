        public static IEnumerable<Range<T>> Collapse<T>(this IEnumerable<Range<T>> me, IComparer<T> comparer)
        {
            List<Range<T>> orderdList = me.OrderBy(r => r.Start).ToList();
            List<Range<T>> newList = new List<Range<T>>();
            T max = orderdList[0].End;
            T min = orderdList[0].Start;
            foreach (var item in orderdList.Skip(1))
            {
                if (comparer.Compare(item.End, max) > 0 && comparer.Compare(item.Start, max) > 0)
                {
                    newList.Add(new Range<T> { Start = min, End = max });
                    min = item.Start;
                }
                max = comparer.Compare(max, item.End) > 0 ? max : item.End;
            }
            newList.Add(new Range<T>{Start=min,End=max});
            return newList;
        }
