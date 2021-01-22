    public static void MergeWith<T>(this T primary, T secondary) {
        foreach (var pi in typeof(T).GetProperties()) {
           var priValue = pi.GetGetMethod().Invoke(primary, null);
           var secValue = pi.GetGetMethod().Invoke(secondary, null);
           if (priValue == null || (pi.PropertyType.IsValueType && priValue == Activator.CreateInstance(pi.PropertyType))) {
              pi.GetSetMethod().Invoke(primary, new object[]{secValue});
           }
        }
    }
