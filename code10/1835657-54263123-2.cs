    /// <summary>
    /// return Json Action Result
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="o"></param>
    /// <param name="JsonFormatting"></param>
    /// <returns></returns>
    public static CallbackJsonResult ViewResult<T>(this T o)
    {
        return new CallbackJsonResult(o);
    }
