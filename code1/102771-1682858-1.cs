    public static TEntity clr_bloat_reflected_msdn_method<TEntity>(string commonString) where TEntity : class
            {
                Assembly a = Assembly.GetExecutingAssembly();
                foreach (Type t in a.GetTypes())
                    if (!t.IsAbstract && typeof(IGetByCommonStringRepository<TEntity>).IsAssignableFrom(t))
                        return ((IGetByCommonStringRepository<TEntity>)Activator.CreateInstance(t)).GetByCommonStringColumn(commonString);
                return null;
            }
