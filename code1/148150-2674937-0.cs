    using System.Collections.Specialized;
    using MyProject.Util;     // <== Don't forget this!
    ...
        var coll = new NameValueCollection();
        coll.Add("blah", "something");
        string value = coll.Get("blah", "default");
