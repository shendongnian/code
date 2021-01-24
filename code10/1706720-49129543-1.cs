      public static WhateverItReturns DisposablePropAll<TDisposable>(this IEnumerable<TDisposable> elements, Action<TDisposable> action) where TDisposable : IDisposable
            {
                return Prop.ForAll(elements, (TDisposable randomClassUnderTest) =>
                {
                    using (randomClassUnderTest)
                    {
                        action(randomClassUnderTest);
                    }
                });
            }
