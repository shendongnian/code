    Debug.Assert("my "+"string" == "mystring"); //true
    var a = new ArrayList();
    a.Add("my "+"string");
    a.Add("mystring");
    // uses ==(object) instead of ==(string)
    Debug.Assert(a[1] == "mystring"); // true, due to interning magic
    Debug.Assert(a[0] == "mystring"); // false
