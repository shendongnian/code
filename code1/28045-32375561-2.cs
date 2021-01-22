        public class ReadOnly<T>
        {
            public T Value { get; private set; }
            public ReadOnly(T pValue)
            {
                Value = pValue;
            }
            public static bool operator ==(ReadOnly<T> pReadOnlyT, T pT)
            {
                if (object.ReferenceEquals(pReadOnlyT, null))
                {
                    return object.ReferenceEquals(pT, null);
                }
                return (pReadOnlyT.Value.Equals(pT));
            }
            public static bool operator !=(ReadOnly<T> pReadOnlyT, T pT)
            {
                return !(pReadOnlyT == pT);
            }
        }
