    public class UnmanagedTypeHelper
    {
        private static void IsUnManaged<T>(T value) where T : unmanaged { }
        public static bool IsUnManaged(Type t)
        {
            try
            {
                MethodInfo method = typeof(UnmanagedTypeHelper)
                    .GetMethod("IsUnManaged", BindingFlags.NonPublic | BindingFlags.Static);
                MethodInfo generic = method.MakeGenericMethod(t);
                generic.Invoke(null, new object[] { null });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
