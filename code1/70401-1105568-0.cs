    public static IEnumerable<T> MapObject(IDataReader dr, Func<IDataReader, T> convertFunction)
            {
                while (dr.Read())
                {
                    yield return convertFunction(dr);
                }
            }
