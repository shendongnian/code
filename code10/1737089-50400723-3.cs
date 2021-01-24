     public class DiscriminatedUnion
    {
        public static IObservable<TInput2> Process<TInput1, TInput2>(
           IObservable<TInput1> input1,
            IObservable<TInput2> input2)
        {
            var merged =
                        input2.Select(s2 => Tuple.Create(2, (object)s2))
                        .Merge(input1.Select(s1 => Tuple.Create(1, (object)s1)))
                        .Scan(Tuple.Create(default(TInput2), new Queue<TInput2>(), 0), (state, val) =>
                        {
                            TInput2 next = state.Item1;
                            if (val.Item1 == 1)
                            {
                                if (state.Item2.Count > 0)
                                {
                                    next = state.Item2.Dequeue();
                                }
                            }
                            else
                            {
                                state.Item2.Enqueue((TInput2)val.Item2);
                            }
                            return Tuple.Create(next, state.Item2, val.Item1);
                        })
                        .Where(x => (!x.Item1.Equals(default(TInput2)) && x.Item3 == 1))
                        .Select(x => x.Item1);
            return merged;
        }
    }
