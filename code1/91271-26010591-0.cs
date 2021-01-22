    public static string GetAddress(object o)
    {
        if (o == null)
        {
            return "00000000";
        }
        else
        {
            unsafe
            {
                System.TypedReference tr = __makeref(o);
                System.IntPtr ptr = **(System.IntPtr**) (&tr);
                return ptr.ToString ("X");
            }
        }
    }
