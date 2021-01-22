    using ok = ok<string>;
    ...
    string bob = null;
    string joe = "joe";
    string name = (ok)bob && bob.ToUpper();   // name == null, no error thrown
    string boss = (ok)joe && joe.ToUpper();   // boss == "JOE"
