    using System.Reflection;
    public static bool SocketIsDisposed(Socket s)
    {
	   BindingFlags bfIsDisposed = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetProperty;
	   // Retrieve a FieldInfo instance corresponding to the field
	   PropertyInfo field = s.GetType().GetProperty("CleanedUp", bfIsDisposed);
	   // Retrieve the value of the field, and cast as necessary
	   return (bool)field.GetValue(s, null);
    }
