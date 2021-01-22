    public static void MoveIndex(this List<T> list, int srcIdx, int destIdx)
    {
      if(srcIdx != destIdx)
      {
        list.Insert(destIdx, list[srcIdx]);
        list.RemoveAt(destIdx < srcIdx ? srcIdx + 1 : srcIdx);
      }
    }
