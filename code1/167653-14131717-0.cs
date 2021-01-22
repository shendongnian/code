    public static TResult SafeNestedUsing<TOuter, TInner, TResult>(Func<TOuter> createOuterDisposable, Func<TOuter, TInner> createInnerDisposable, Func<TInner, TResult> body)
            where TInner : IDisposable
            where TOuter : class, IDisposable
        {
            TOuter outer = null;
            try
            {
                outer = createOuterDisposable();
                using (var inner = createInnerDisposable(outer))
                {
                    var result = body(inner);
                    outer = null;
                    return result;
                }
            }
            finally
            {
                if (null != outer)
                {
                    outer.Dispose();
                }
            }
        }
