    public static Boolean Next(this Boolean[] list)
    {
        Int32 lastOneIndex = Array.LastIndexOf(list, true);
        if (lastOneIndex == -1)
        {
            return false; // All zeros. 0000000
        }
        else if (lastOneIndex < list.Length - 1)
        {
            // Move the last one right once. 1100X00 => 11000X0
            list.MoveBlock(lastOneIndex, lastOneIndex, lastOneIndex + 1);
        }
        else
        {
            Int32 lastZeroIndex = Array.LastIndexOf(list, false, lastOneIndex);
            if (lastZeroIndex == -1)
            {
                return false; // All ones. 1111111
            }
            else
            {
                Int32 blockEndIndex = Array.LastIndexOf(list, true, lastZeroIndex);
                if (blockEndIndex == -1)
                {
                    // Move all ones back to the very left. 0000XXX => XXX0000
                    list.MoveBlock(lastZeroIndex + 1, lastOneIndex, 0);
                    return false; // Back at initial position.
                }
                else
                {
                    // Move the block end right once. 11X0011 => 110X011
                    list.MoveBlock(blockEndIndex, blockEndIndex, blockEndIndex + 1);
                    // Move the block of ones from the very right back left. 11010XX => 1101XX0
                    list.MoveBlock(lastZeroIndex + 1, lastOneIndex, blockEndIndex + 2);
                }
            }
        }
        return true;
    }
