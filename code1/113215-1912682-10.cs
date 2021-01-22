    public class Group{ ....
            public IList<object> Items
            {
                get
                {
                    IList<object> childNodes = new List<object>();
                    foreach (var group in this.SubGroups)
                        childNodes.Add(group);
                    foreach (var entry in this.Entries)
                        childNodes.Add(entry);
    
                    return childNodes;
                }
            }
