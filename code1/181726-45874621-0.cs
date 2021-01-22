     public List<T> GetTsRate( List<T> AllT,int Index,int Count)
            {
                List<T> Ts = null;
                try
                {
                    Ts = AllT.ToList().GetRange(Index, Count);
                }
                catch (Exception ex)
                {
                    Ts = AllT.Skip(Index).ToList();
                }
                return Ts ;
            }
