        /// <summary>
        /// Returns the ordinate of a coordinate in this sequence.
        /// Ordinate indices 0 and 1 are assumed to be X and Y.
        /// Ordinate indices greater than 1 have user-defined semantics
        /// (for instance, they may contain other dimensions or measure values).
        /// </summary>
        /// <param name="index">The coordinate index in the sequence.</param>
        /// <param name="ordinate">The ordinate index in the coordinate (in range [0, dimension-1]).</param>
        /// <returns></returns>
        public double GetOrdinate(int index, Ordinate ordinate)
        {
            switch (ordinate)
            {
                case Ordinate.X:
                    return Coordinates[index].X;
                case Ordinate.Y:
                    return Coordinates[index].Y;
                case Ordinate.Z:
                    return Coordinates[index].Z;
                default:
                    return double.NaN;
            }
        }
        /// <summary>
        /// Sets the value for a given ordinate of a coordinate in this sequence.
        /// </summary>
        /// <param name="index">The coordinate index in the sequence.</param>
        /// <param name="ordinate">The ordinate index in the coordinate (in range [0, dimension-1]).</param>
        /// <param name="value">The new ordinate value.</param>
        public void SetOrdinate(int index, Ordinate ordinate, double value)
        {
            switch (ordinate)
            {
                case Ordinate.X:
                    Coordinates[index].X = value;
                    break;
                case Ordinate.Y:
                    Coordinates[index].Y = value;
                    break;
                case Ordinate.Z:
                    Coordinates[index].Z = value;
                    break;
                //default:
                //    //throw new ArgumentException("invalid ordinate index: " + ordinate);
            }
        }
