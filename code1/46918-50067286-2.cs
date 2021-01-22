    public static void CopyOnlyEqualProperties<T>(this T objDest, object objSource) where T : class
        {
            foreach (PropertyInfo propInfo in typeof(T).GetProperties())
                if (objSource.GetType().GetProperties().Any(z => z.Name == propInfo.Name && z.GetType() == propInfo.GetType()))
                    propInfo.SetValue(objDest, objSource.GetType().GetProperties().First(z => z.Name == propInfo.Name && z.GetType() == propInfo.GetType()).GetValue(objSource));
        }
