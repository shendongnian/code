    using System.Linq;
    
    List<MyProperty> _Group = new List<MyProperty>();
    // ... add elements
    bool cond = true;
    foreach (MyProperty currObj in _Group)
    {
        if (cond) 
        {
            // SET - element can be deleted
            currObj.REMOVE_ME = true;
        }
    }
    // RESET
    _Group.RemoveAll(r => r.REMOVE_ME);
