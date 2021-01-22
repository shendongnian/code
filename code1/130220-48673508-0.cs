        static void Main(string[] args) {
            var list1 = new List<int?>() {
                1,3,5,9,11
            };
            var list2 = new List<int?>() {
                2,5,6,11,15,17,19,29
            };
            foreach (var c in SortedAndMerged(list1.GetEnumerator(), list2.GetEnumerator())) {
                Console.Write(c+" ");
            }
            
            Console.ReadKey();
        }
        private static IEnumerable<int> SortedAndMerged(IEnumerator<int?> e1, IEnumerator<int?> e2) {
            e2.MoveNext();
            e1.MoveNext();
            do {
                while (e1.Current < e2.Current) {
                    if (e1.Current != null) yield return e1.Current.Value;
                    e1.MoveNext();
                }
                if (e2.Current != null) yield return e2.Current.Value;
                e2.MoveNext();
            } while (!(e1.Current == null && e2.Current == null));
        }
    }
