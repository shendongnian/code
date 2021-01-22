            private class c : IEqualityComparer<Tuple<string,int?>>
            {
                #region IEqualityComparer<Tuple<string,int?>> Members
                public bool Equals(Tuple<string, int?> x, Tuple<string, int?> y)
                {
                    if (x.a.Equals(x.a) && x.b.Equals(y.b))
                        return true;
                    return false;
                }
                public int GetHashCode(Tuple<string, int?> obj)
                {
                    throw new NotImplementedException();
                }
                #endregion
            }
