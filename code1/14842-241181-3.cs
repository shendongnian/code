    string my = "my ";
    Debug.Assert(my+"string" == "my string"); //true
    var a = new ArrayList();
    a.Add(my+"string");
    a.Add("my string");
    // uses ==(object) instead of ==(string)
    Debug.Assert(a[1] == "my string"); // true, due to interning magic
    Debug.Assert(a[0] == "my string"); // false
