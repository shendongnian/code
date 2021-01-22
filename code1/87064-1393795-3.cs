    public Element GetAnyoneElseFromTheList(Element el)
    {
        // first create a new list and populate it with all non-matching elements
        List<Element> temp = new List<Element>();
        this.ElementList.ForEach(delegate(int i) { if (i != el) temp.Add(i); });
        // if we have some matching elements then return one of them at random
        if (temp.Count > 0) return temp[new Random().Next(0, temp.Count)];
        // if there are no matching elements then take the appropriate action
        // throw an exception, return null, return default(Element) etc
        throw new Exception("No items found!");
    }
