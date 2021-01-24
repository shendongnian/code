    public static IEnumerable<T> InterlockWith<T>(this IEnumerable<T> seq1, IEnumerable<T> seq2)
        {
            Tuple<T[], int>[] metaSequences = new Tuple<T[], int>[2];
            metaSequences[0] = Tuple.Create(seq1.ToArray(), seq1.Count());
            metaSequences[1] = Tuple.Create(seq2.ToArray(), seq2.Count());
            var orderedMetas = metaSequences.OrderBy(x => x.Item2).ToArray();
    
            for (int i = 0; i < orderedMetas[0].Item2; i++)
            {
                yield return metaSequences[0].Item1[i];
                yield return metaSequences[1].Item1[i];
            }
    
            var remainingItems = orderedMetas[1].Item1.Skip(orderedMetas[0].Item2);
            foreach (var item in remainingItems)
            {
                yield return item;
            }
        }
