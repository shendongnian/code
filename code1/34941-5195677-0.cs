public static String ToString(this Object obj)
{
    if (obj == null)
    {
        return "null";
    }
    else
    {
        return obj.GetType().Name;
    }
}
