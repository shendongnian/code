    class Person
    {
       readonly List<Person> _children = new List<Person>(), 
                             _parents = new List<Person>();
       public IEnumerable<Person> Children 
       { 
          get { return _children.AsReadOnly(); } 
       }
       public IEnumerable<Person> Parents 
       { 
          get { return _parents.AsReadOnly(); } 
       }
       public void AddChild(Person child)
       {
           _children.Add(child);
           child._parents.Add(this);
       }
       public void AddParent(Person parent)
       {
           _parents.Add(parent);
           parent._children.Add(this);
       }
       /* And so on... */
    }
