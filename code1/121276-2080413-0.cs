        public class Foo<T> : IEquatable<Foo<T>> where T : struct
        {
            List<T> lst;
            #region IEquatable<T> Members
            public bool Equals(Foo<T> other)
            {
                if (lst.Count != other.lst.Count) {
                    return false;
                }
                return lst.Equals(other.lst);
            }
            #endregion
            public override bool Equals(object obj)
            {
                var other = obj as Foo<T>;
                return other != null && Equals(other);
            }
            public override int GetHashCode()
            {
                return lst.GetHashCode();
            }
        }
