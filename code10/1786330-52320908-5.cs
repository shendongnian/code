    public class Box : IEquatable<Box>
    {
        // Place values in constants
        public const double SizeTolerance = 0.001;
        public double Width { get; set; }
        public double Height { get; set; }
        public static bool operator ==(Box left, Box right)
        {
            if(!ReferenceEquals(left, null))
            {
                // consider that left.Equals(null) should return false
                return left.Equals(right);
            }
            return ReferenceEquals(left, right);
        }
        public static bool operator !=(Box left, Box right)
        {
            return !(left==right);
        }
        #region IEquatable Members
        /// <summary>
        /// Equality overrides from <see cref="System.Object"/>
        /// </summary>
        /// <param name="obj">The object to compare this with</param>
        /// <returns>False if object is a different type, otherwise it calls <code>Equals(Box)</code></returns>
        public override bool Equals(object obj)
        {
            if(obj is Box other)
            {
                return Equals(other);
            }
            return false;
        }
        /// <summary>
        /// Checks for equality among <see cref="Box"/> classes
        /// </summary>
        /// <param name="other">The other <see cref="Box"/> to compare it to</param>
        /// <returns>True if equal</returns>
        public bool Equals(Box other)
        {
            if(ReferenceEquals(other, null))
            {
                return false;
            }
            return Math.Abs(Width-other.Width)<SizeTolerance
                && Math.Abs(Height-other.Height)<SizeTolerance;
        }
        /// <summary>
        /// Calculates the hash code for the <see cref="Box"/>
        /// </summary>
        /// <returns>The int hash value</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hc = 17;
                hc = 23*hc + Width.GetHashCode();
                hc = 23*hc + Height.GetHashCode();
                return hc;
            }
        }
        #endregion
        public override string ToString()
        {
            return $"[{Width}×{Height}]";
        }
    }
