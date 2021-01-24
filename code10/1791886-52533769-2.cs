    public class Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> : IStructuralEquatable, IStructuralComparable, IComparable, ITupleInternal, ITuple {
 
        private readonly T1 m_Item1;
        private readonly T2 m_Item2;
        private readonly T3 m_Item3;
        private readonly T4 m_Item4;
        private readonly T5 m_Item5;
        private readonly T6 m_Item6;
        private readonly T7 m_Item7;
        private readonly TRest m_Rest;
 
        public T1 Item1 { get { return m_Item1; } }
        public T2 Item2 { get { return m_Item2; } }
        public T3 Item3 { get { return m_Item3; } }
        public T4 Item4 { get { return m_Item4; } }
        public T5 Item5 { get { return m_Item5; } }
        public T6 Item6 { get { return m_Item6; } }
        public T7 Item7 { get { return m_Item7; } }
        public TRest Rest { get { return m_Rest; } }
 
        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, TRest rest) {
            if (!(rest is ITupleInternal)) {
                throw new ArgumentException(Environment.GetResourceString("ArgumentException_TupleLastArgumentNotATuple"));
            }
 
            m_Item1 = item1;
            m_Item2 = item2;
            m_Item3 = item3;
            m_Item4 = item4;
            m_Item5 = item5;
            m_Item6 = item6;
            m_Item7 = item7;
            m_Rest = rest;
        }
 
        public override Boolean Equals(Object obj) {
            return ((IStructuralEquatable) this).Equals(obj, EqualityComparer<Object>.Default);;
        }
 
        Boolean IStructuralEquatable.Equals(Object other, IEqualityComparer comparer) {
            if (other == null) return false;
 
            Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> objTuple = other as Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>;
 
            if (objTuple == null) {
                return false;
            }
 
            return comparer.Equals(m_Item1, objTuple.m_Item1) && comparer.Equals(m_Item2, objTuple.m_Item2) && comparer.Equals(m_Item3, objTuple.m_Item3) && comparer.Equals(m_Item4, objTuple.m_Item4) && comparer.Equals(m_Item5, objTuple.m_Item5) && comparer.Equals(m_Item6, objTuple.m_Item6) && comparer.Equals(m_Item7, objTuple.m_Item7) && comparer.Equals(m_Rest, objTuple.m_Rest);
        }
 
        Int32 IComparable.CompareTo(Object obj) {
            return ((IStructuralComparable) this).CompareTo(obj, Comparer<Object>.Default);
        }
 
        Int32 IStructuralComparable.CompareTo(Object other, IComparer comparer) {
            if (other == null) return 1;
 
            Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> objTuple = other as Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>;
 
            if (objTuple == null) {
                throw new ArgumentException(Environment.GetResourceString("ArgumentException_TupleIncorrectType", this.GetType().ToString()), "other");
            }
 
            int c = 0;
 
            c = comparer.Compare(m_Item1, objTuple.m_Item1);
 
            if (c != 0) return c;
 
            c = comparer.Compare(m_Item2, objTuple.m_Item2);
 
            if (c != 0) return c;
 
            c = comparer.Compare(m_Item3, objTuple.m_Item3);
 
            if (c != 0) return c;
 
            c = comparer.Compare(m_Item4, objTuple.m_Item4);
 
            if (c != 0) return c;
 
            c = comparer.Compare(m_Item5, objTuple.m_Item5);
 
            if (c != 0) return c;
 
            c = comparer.Compare(m_Item6, objTuple.m_Item6);
 
            if (c != 0) return c;
 
            c = comparer.Compare(m_Item7, objTuple.m_Item7);
 
            if (c != 0) return c;
 
            return comparer.Compare(m_Rest, objTuple.m_Rest);
        }
 
        public override int GetHashCode() {
            return ((IStructuralEquatable) this).GetHashCode(EqualityComparer<Object>.Default);
        }
 
        Int32 IStructuralEquatable.GetHashCode(IEqualityComparer comparer) {
            // We want to have a limited hash in this case.  We'll use the last 8 elements of the tuple
            ITupleInternal t = (ITupleInternal) m_Rest;
            if(t.Length >= 8) { return t.GetHashCode(comparer); }
            
            // In this case, the rest memeber has less than 8 elements so we need to combine some our elements with the elements in rest
            int k = 8 - t.Length;
            switch(k) {
                case 1:
                return Tuple.CombineHashCodes(comparer.GetHashCode(m_Item7), t.GetHashCode(comparer));
                case 2:
                return Tuple.CombineHashCodes(comparer.GetHashCode(m_Item6), comparer.GetHashCode(m_Item7), t.GetHashCode(comparer));
                case 3:
                return Tuple.CombineHashCodes(comparer.GetHashCode(m_Item5), comparer.GetHashCode(m_Item6), comparer.GetHashCode(m_Item7), t.GetHashCode(comparer));
                case 4:
                return Tuple.CombineHashCodes(comparer.GetHashCode(m_Item4), comparer.GetHashCode(m_Item5), comparer.GetHashCode(m_Item6), comparer.GetHashCode(m_Item7), t.GetHashCode(comparer));
                case 5:
                return Tuple.CombineHashCodes(comparer.GetHashCode(m_Item3), comparer.GetHashCode(m_Item4), comparer.GetHashCode(m_Item5), comparer.GetHashCode(m_Item6), comparer.GetHashCode(m_Item7), t.GetHashCode(comparer));
                case 6:
                return Tuple.CombineHashCodes(comparer.GetHashCode(m_Item2), comparer.GetHashCode(m_Item3), comparer.GetHashCode(m_Item4), comparer.GetHashCode(m_Item5), comparer.GetHashCode(m_Item6), comparer.GetHashCode(m_Item7), t.GetHashCode(comparer));
                case 7:
                return Tuple.CombineHashCodes(comparer.GetHashCode(m_Item1), comparer.GetHashCode(m_Item2), comparer.GetHashCode(m_Item3), comparer.GetHashCode(m_Item4), comparer.GetHashCode(m_Item5), comparer.GetHashCode(m_Item6), comparer.GetHashCode(m_Item7), t.GetHashCode(comparer));
            }
            Contract.Assert(false, "Missed all cases for computing Tuple hash code");
            return -1;
        }
 
        Int32 ITupleInternal.GetHashCode(IEqualityComparer comparer) {
            return ((IStructuralEquatable) this).GetHashCode(comparer);
        }
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            return ((ITupleInternal)this).ToString(sb);
        }
 
        string ITupleInternal.ToString(StringBuilder sb) {
            sb.Append(m_Item1);
            sb.Append(", ");
            sb.Append(m_Item2);
            sb.Append(", ");
            sb.Append(m_Item3);
            sb.Append(", ");
            sb.Append(m_Item4);
            sb.Append(", ");
            sb.Append(m_Item5);
            sb.Append(", ");
            sb.Append(m_Item6);
            sb.Append(", ");
            sb.Append(m_Item7);
            sb.Append(", ");
            return ((ITupleInternal)m_Rest).ToString(sb);
        }
 
        /// <summary>
        /// The number of positions in this data structure.
        /// </summary>
        int ITuple.Length
        {
            get
            {
                return 7 + ((ITupleInternal)Rest).Length;
            }
        }
 
        /// <summary>
        /// Get the element at position <param name="index"/>.
        /// </summary>
        object ITuple.this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return Item1;
                    case 1:
                        return Item2;
                    case 2:
                        return Item3;
                    case 3:
                        return Item4;
                    case 4:
                        return Item5;
                    case 5:
                        return Item6;
                    case 6:
                        return Item7;
                }
 
                return ((ITupleInternal)Rest)[index - 7];
            }
        }
    }
