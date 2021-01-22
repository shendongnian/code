    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    public sealed class ReferenceEqualityComparer
        : IEqualityComparer, IEqualityComparer<object>
    {
        public static readonly ReferenceEqualityComparer Default
            = new ReferenceEqualityComparer(); // JIT-lazy is sufficiently lazy imo.
        private ReferenceEqualityComparer() { } // <-- A matter of opinion / style.
        public bool Equals(object x, object y)
        {
            return x == y; // This is reference equality! (See explanation below.)
        }
        public int GetHashCode(object obj)
        {
            return RuntimeHelpers.GetHashCode(obj);
        }
    }
