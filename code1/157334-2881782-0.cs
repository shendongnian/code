    public static TEntity CopyTo<TEntity>(this TEntity OriginalEntity, TEntity NewEntity)
        {
            PropertyInfo[] oProperties = OriginalEntity.GetType().GetProperties();
            foreach (PropertyInfo CurrentProperty in oProperties.Where(p => p.CanWrite))
            {
                if (CurrentProperty.GetValue(NewEntity, null) != null)
                {
                    CurrentProperty.SetValue(OriginalEntity, CurrentProperty.GetValue(NewEntity, null), null);
                }
            }
            return OriginalEntity;
        }
