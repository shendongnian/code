            public TResult DoCall<TResult,TProvider>(Func<TProvider, TResult> action) where TProvider : class, IProvider
            {
                TResult ret = default(TResult);
                try
                {
                    var prov = (TProvider) ModelManagerProvider.GetProviderByType(typeof(TProvider));
                    ret = action(prov);
                }
                catch (Exception ex)
                {
                    ThrowErrorTool.ThrowError(ex);
                }
                return ret;
            }
