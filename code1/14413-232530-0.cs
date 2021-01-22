        public class Pair&lt;T&gt; {
            public int Index;
            public T Value;
            public Pair(int i, T v) {
                Index = i;
                Value = v;
            }
        }
        static IEnumerable&lt;Pair&lt;T&gt;&gt; Iterate&lt;T&gt;(this IEnumerable&lt;T&gt; source) {
            int index = 0;
            foreach ( var cur in source) {
                yield return new Pair&lt;T&gt;(index,cur);
                index++;
            }
        }
        static void Sort2d(string[][] source, IComparer<string> comp, int col) {
            var colValues = source.Iterate()
                .Select(x => new Pair&lt;string&gt;(x.Index,source[x.Index][col])).ToList();
            colValues.Sort((l,r) => comp.Compare(l.Value, r.Value));
            var temp = new string[source[0].Length];
            var rest = colValues.Iterate();
            while ( rest.Any() ) {
                var pair = rest.First();
                var cur = pair.Value;
                var i = pair.Index;
                if (i == cur.Index ) {
                    rest = rest.Skip(1);
                    continue;
                }
                Array.Copy(source[i], temp, temp.Length);
                Array.Copy(source[cur.Index], source[i], temp.Length);
                Array.Copy(temp, source[cur.Index], temp.Length);
                rest = rest.Skip(1);
                rest.Where(x =&gt; x.Value.Index == i).First().Value.Index = cur.Index;
            }
        }
        public static void Test1() {
            var source = new string[][] 
            {
                new string[]{ "foo", "bar", "4" },
                new string[] { "jack", "dog", "1" },
                new string[]{ "boy", "ball", "2" },
                new string[]{ "yellow", "green", "3" }
            };
            Sort2d(source, StringComparer.Ordinal, 2);
        }
