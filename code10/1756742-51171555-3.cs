    static void appUpdater(object p) {
        Dictionary<string, object> tp = p as Dictionary<string, object>;
    }
    Thread wms = new Thread(new ParameterizedThreadStart(appUpdater));
    wms.Start(new Dictionary<string, object>{{"p1", "p1"}, {"p2", "p2}});
