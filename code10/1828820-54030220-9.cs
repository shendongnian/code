    var t = Utils.DynamicInherit<BaseTest>("Extended", To.Action((baseO, objects) => {
        foreach(var t in objects) {
            baseTest.IsNotNull = t;
        }}).Method,
        extendwith);
