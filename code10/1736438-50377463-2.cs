    private static IEnumerable<MyObject> OrderChain(List<MyObject> myObjects)
        {
            var starter = myObjects.FirstOrDefault(x => x.NextObjectId == null);
            yield return starter;
            var count = myObjects.Count;
            while (count > 1)
            {
                var current = GetCurrent(myObjects, ref starter);
                yield return current;
                count--;
            }
        }
    private static MyObject GetCurrent(List<MyObject> lst, ref MyObject current)
        {
            var id = current.Id;
            current = lst.SingleOrDefault(x => x.NextObjectId == id);
            return current;
        }
