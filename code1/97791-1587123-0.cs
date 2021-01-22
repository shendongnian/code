        public enum forEachExeuction
        {
            Concurrent,
            Seperate
        }
        public delegate void forEachDelegate(object o);
        public static void forEach(
            IList collection,
            forEachDelegate function,
            forEachDelegate before,
            forEachDelegate first,
            forEachDelegate evens,
            forEachDelegate odds,
            forEachDelegate last,
            forEachDelegate after,
            forEachExeuction when)
        {
            bool doBefore = before != null;
            bool doFirst = first != null;
            bool doEvens = evens != null;
            bool doOdds = odds != null;
            bool doLast = last != null;
            bool doAfter = after != null;
            bool conCurrent = when == forEachExeuction.Concurrent;
            int collectionCount = collection.Count;
            for (int i = 0; i < collectionCount; i++)
            {
                if (doBefore && i == 0)
                {
                    before(collection[i]);
                }
                if (doFirst && i == 0)
                {
                    first(collection[i]);
                    if (conCurrent)
                        function(collection[i]);
                }
                else if (doEvens && i % 2 != 0)
                {
                    evens(collection[i]);
                    if (conCurrent)
                        function(collection[i]);
                }
                else if (doOdds && i % 2 == 0)
                {
                    odds(collection[i]);
                    if (conCurrent)
                        function(collection[i]);
                }
                else if (doLast && i == collectionCount - 1)
                {
                    last(collection[i]);
                    if (conCurrent)
                        function(collection[i]);
                }
                else
                {
                    function(collection[i]);
                }
                if (after != null && i == collectionCount - 1)
                {
                    after(collection[i]);
                }
            }
        }
