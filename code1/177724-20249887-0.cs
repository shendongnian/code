     public static class ExtensionMethods
    {
        public static TEntity CopyTo<TEntity>(this TEntity OriginalEntity, TEntity EntityToMergeOn)
        {
            PropertyInfo[] oProperties = OriginalEntity.GetType().GetProperties();
            foreach (PropertyInfo CurrentProperty in oProperties.Where(p => p.CanWrite))
            {
                var originalValue = CurrentProperty.GetValue(EntityToMergeOn);
                if (originalValue != null)
                {
                    IListLogic<TEntity>(OriginalEntity, CurrentProperty, originalValue);
                }
                else
                {
                    var value = CurrentProperty.GetValue(OriginalEntity, null);
                    CurrentProperty.SetValue(EntityToMergeOn, value, null);
                }
            }
            return OriginalEntity;
        }
        private static void IListLogic<TEntity>(TEntity OriginalEntity, PropertyInfo CurrentProperty, object originalValue)
        {
            if (originalValue is IList)
            {
                var tempList = (originalValue as IList);
                var existingList = CurrentProperty.GetValue(OriginalEntity) as IList;
                foreach (var item in tempList)
                {
                    existingList.Add(item);
                }
            }
        }
    }
