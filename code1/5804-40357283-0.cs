    public static int ToInt<T>(this T soure) where T : IConvertible//enum
    {
        //if (!typeof(T).IsEnum)
        //{
        //    throw new ArgumentException("T must be an enumerated type");
        //}
        if (typeof(T).IsEnum)
        {
            return (int) (IConvertible)soure;// the tricky part
        }
        return soure.ToInt32(CultureInfo.CurrentCulture);
    }
