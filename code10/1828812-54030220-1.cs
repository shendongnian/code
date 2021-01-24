    var t = Utils.DynamicInherit<BaseTest>("Extended",((Action<BaseTest,List<object>>)((baseO, objects) => {foreach(var t in objects)
        {
            baseTest.IsNotNull = t;
        }})).Method,
        extendwith);
