    var A = new TestThreading();
    var B = new TestThreading();
    ((Action)(A.DoStuff1)).BeginInvoke(null,null); // These can go concurrently
    ((Action)(B.DoStuff1)).BeginInvoke(null,null); // just fine
    ((Action)(A.DoStuff1)).BeginInvoke(null,null); // These will have to wait
    ((Action)(A.DoStuff1)).BeginInvoke(null,null);
    ((Action)(A.DoStuff2)).BeginInvoke(null,null); // These will have to wait
    ((Action)(B.DoStuff2)).BeginInvoke(null,null);
