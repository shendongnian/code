        internal static int GetSign(double d)
        {
            return d > 0 ? 1 : 0;
        }
        public override int GetHashCode()
        {
            var signs = GetSign(d2) << 1 | GetSign(d1);
            var h = CombineHashCodes(d1.GetHashCode(), d2.GetHashCode());
            return h ^ signs;
        }
