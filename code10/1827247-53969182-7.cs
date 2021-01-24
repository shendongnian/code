    using System;
    using System.Reflection;
    public static class UnmanagedTypeExtensions
    {
        class U<T> where T : unmanaged { }
        public static bool IsUnManaged(this Type t)
        {
            try
            {
                typeof(U<>).MakeGenericType(t);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
