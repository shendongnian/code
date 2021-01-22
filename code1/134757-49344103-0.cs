       public static IEnumerable<IEnumerable<T>> PageIterator<T>(this IQueryable<T> source, int pageSize)
                {
                    Contract.Requires(source != null);
                    Contract.Requires(pageSize > 0);
                    Contract.Ensures(Contract.Result<IEnumerable<IQueryable<T>>>() != null);
        
                    using (var enumerator = source.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            var currentPage = new List<T>(pageSize)
                            {
                                enumerator.Current
                            };
        
                            while (currentPage.Count < pageSize && enumerator.MoveNext())
                            {
                                currentPage.Add(enumerator.Current);
                            }
                            yield return new ReadOnlyCollection<T>(currentPage);
                        }
                    }
                }
