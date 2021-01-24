        public double M
        {
            get
            {
                if (CoordinateSequence == null)
                    throw new ArgumentOutOfRangeException("M called on empty Point");
                return CoordinateSequence.GetOrdinate(0, Ordinate.M);
            }
            set => CoordinateSequence.SetOrdinate(0, Ordinate.M, value);
        }
