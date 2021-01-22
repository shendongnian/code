        public class Foo<T> : IEquatable<Foo<T>> where T : struct
        {
            List<T> lst;
            #region IEquatable<T> Members
            public bool Equals(Foo<T> other)
            {
                if (lst.Count != other.lst.Count)
                {
                    return false;
                }
                for (int i = 0; i < lst.Count; i++)
                {
                    if (!lst[i].Equals(other.lst[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            #endregion
            public override bool Equals(object obj)
            {
                var other = obj as Foo<T>;
                return other != null && Equals(other);
            }
         
        }
