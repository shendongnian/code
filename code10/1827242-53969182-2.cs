    using System;
    using System.Reflection;
    public static class UnmanagedTypeExtensions
    {
        private static void IsUnManaged<T>() where T : unmanaged { }
        public static bool IsUnManaged(this Type t)
        {
            try
            {
                MethodInfo method = typeof(UnmanagedTypeExtensions)
                    .GetMethod("IsUnManaged", BindingFlags.NonPublic | BindingFlags.Static);
                MethodInfo generic = method.MakeGenericMethod(t);
                generic.Invoke(null, null);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
