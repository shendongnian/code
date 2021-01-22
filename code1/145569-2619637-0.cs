    class VehicleNumberComparer : IComparer<string>
    {
        public int Compare(string lhs, string rhs)
        {
            var numExtract = new Regex("[0-9]+");
            int lhsNumber = int.Parse(numExtract.Match(lhs).Value);
            int rhsNumber = int.Parse(numExtract.Match(rhs).Value);
            return lhsNumber.CompareTo(rhsNumber);
        }
    }
