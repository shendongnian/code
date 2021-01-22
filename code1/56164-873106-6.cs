    class SomeWrapper {
        public string category;
        public bool AnonMethod(XElement c) {
            return c.Attribute("Name").Value == category;
        }
    }
    ...
    SomeWrapper wrapper = new SomeWrapper(); // note only 1 of these
    using(var iter = categories.GetEnumerator()) {
        while(iter.MoveNext()) {
            wrapper.category = iter.Current;
            query = query.Elements("Category")
                 .Where(wrapper.AnonMethod);
        }
    }
