    class Heavy{
        static Heavy first;
        static Heavy second;
        public static Heavy First{
            get{
                if(first == null)
                    first = new Heavy();
                return first;
            }
        }
        public static Heavy Second{
            get{
                if(second == null)
                    second = new Heavy();
                return second;
            }
        }
    }
