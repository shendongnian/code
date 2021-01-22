    class SecondWrapper {
        public string tmp;
        public bool AnonMethod(XElement c) {
            return c.Attribute("Name").Value == tmp;
        }
    }
    ...
    string category;
    using(var iter = categories.GetEnumerator()) {
        while(iter.MoveNext()) {
            category = iter.Current;
            SecondWrapper wrapper = new SecondWrapper(); // note 1 per iteration
            wrapper.tmp = category;
            query = query.Elements("Category")
                 .Where(wrapper.AnonMethod);
        }
    }
