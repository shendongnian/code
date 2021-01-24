    class ThreadParameters {
        public string p1 {get;set;}
        public string p2 {get;set;}
    }
    static void appUpdater(p : object) {
        ThreadParameters tp = p as ThreadParameters;
    }
    Thread wms = new Thread(new ParameterizedThreadStart(appUpdater));
    wms.Start(new ThreadParameters{p1="p1", p2= "p2"});
