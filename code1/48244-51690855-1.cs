    public static IThing Pop(this List<IThing> list)
    {
      if (list == null || list.Count == 0) return default(IThing);
      // get last item to return
      var thing = list[list.Count - 1];
      // remove last item
      list.RemoveAt(list.Count-1);
      return thing;
    }
    public static IThing Peek(this List<IThing> list)
    {
      if (list == null || list.Count == 0) return default(IThing);
      // get last item to return
      return list[list.Count - 1];
    }
    public static void Remove(this List<IThing> list, IThing thing)
    {
      if (list == null || list.Count == 0) return;
      if (!list.Contains(thing)) return;
      list.Remove(thing); // only removes the first it finds
    }
    public static void Insert(this List<IThing> list, int index, IThing thing)
    {
      if (list == null || index > list.Count || index < 0) return;
      list.Insert(index, thing);
    }
