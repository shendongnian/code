    private static IEnumerable<MyObject> OrderChain(List<MyObject> myObjects)
        {
            var starter = myObjects.FirstOrDefault(x => x.NextObjectId == null);
            yield return starter;
            var count = myObjects.Count;
            while (count > 1)
            {
                yield return GetCurrent(myObjects, ref starter);
                count--;
            }
        }
    private static MyObject GetCurrent(List<MyObject> lst, ref MyObject current)
        {
            var id = current.Id;
            current = lst.SingleOrDefault(x => x.NextObjectId == id);
            return current;
        }
