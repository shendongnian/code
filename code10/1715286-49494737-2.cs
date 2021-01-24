    public static int[] MoveFirstToLast (this int[] obj)
    {
        int movedValue = obj[0];
        (int i = 1; i < obj.Length; i++)
        {
            obj[i - 1] = obj[i];
        }
        obj[obj.Length - 1] = movedValue;
        return obj;
    }
