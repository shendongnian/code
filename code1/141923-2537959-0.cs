    class CarEqualityComparer : IEqualityComparer<Car>
    {
        #region IEqualityComparer<Car> Members
        public bool Equals(Car x, Car y)
        {
            return x.CarCode.Equals(y.CarCode);
        }
        public int GetHashCode(Car obj)
        {
            return obj.CarCode.GetHashCode();
        }
        #endregion
    }
