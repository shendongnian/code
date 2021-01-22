    string[] results = System.IO.Directory.GetFiles("\\\\sharepath\\here", "FooBar.*", System.IO.SearchOption.AllDirectories);
    
    if(results.Length > 0) {
        //found it
        DoSomethingWith(results[0]);
    } else {
        // :(
    }
