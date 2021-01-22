        public static Singletong GetInstance() {
          if (instance == null) {
            instance = new Singleton(); //here we re-evalute cache for example
           }
        return instance
        }
        public static void Reset() {
            instance = null;
        } 
