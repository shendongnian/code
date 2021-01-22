    public static void MoveBlock(this Boolean[] list, Int32 oldStart, Int32 oldEnd, Int32 newStart)
    {
        list.ClearBlock(oldStart, oldEnd);
        list.SetBlock(newStart, newStart + oldEnd - oldStart);
    }
    public static void SetBlock(this Boolean[] list, Int32 start, Int32 end)
    {
        list.SetBlockToValue(start, end, true);
    }
    public static void ClearBlock(this Boolean[] list, Int32 start, Int32 end)
    {
        list.SetBlockToValue(start, end, false);
    }
    public static void SetBlockToValue(this Boolean[] list, Int32 start, Int32 end, Boolean value)
    {
        for (int i = start; i <= end; i++)
        {
            list[i] = value;
        }
    }
