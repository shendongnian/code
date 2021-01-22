    class Pair<T> {
        public T First { get; private set; }
        public T Second { get; private set; }
        public Pair(T first, T second) {
            First = first;
            Second = second;
        }
        public override int GetHashCode() {
            return First.GetHashCode() ^ Second.GetHashCode();
        }
        public override bool Equals(object other) {
            Pair<T> pair = other as Pair<T>;
            if (pair == null) {
                return false;
            }
            return (this.First.Equals(pair.First) && this.Second.Equals(pair.Second));
        }
    }
    class PairComparer<T> : IComparer<Pair<T>> where T : IComparable {
        public int Compare(Pair<T> x, Pair<T> y) {
            if (x.First.CompareTo(y.First) < 0) {
                return -1;
            }
            else if (x.First.CompareTo(y.First) > 0) {
                return 1;
            }
            else {
                return x.Second.CompareTo(y.Second);
            }
        }
    }
