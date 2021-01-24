        // 'where class' constraint is required because we'll return null as default value
        private static TResult GetModels<T, TResult>(T dto) where TResult : class
        {
            if (dto != null)
            {
                try
                {
                    TResult model = null;
                    // here we check if the actual mapping exists in AM configuration
                    var map = Mapper.Configuration.FindTypeMapFor<T, TResult>();
                    if (map != null)
                    {
                        model = Mapper.Map<T, TResult>(dto);
                    }
                    return model;
                }
                catch (Exception ex)
                {
                   // log other errors here
                }
            }
            return default(TResult);
        }
