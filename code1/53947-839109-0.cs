    public static T[] RemoveElement<T>(T[] original, int elementToRemove)
    {
        T[] ret = new T[original.Length-1];
        Array.Copy(original, 0, ret, 0, elementToRemove);
        Array.Copy(original, elementToRemove+1, ret, elementToRemove,
                   ret.Length - elementToRemove);
        return ret;
    }
