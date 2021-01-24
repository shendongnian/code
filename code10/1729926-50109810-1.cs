    public class Data1 {
        public string variable0;
        public string variable1;
        public string variable2;
        public string variable3;
        public string variable4;
        public string variable5;
        public string variable6;
        public string variable7;
        public string variable8;
        public string variable9;
        public string variable10;
    
        public delegate ref string RefStringFunc();
    
        private List<RefStringFunc> refvar;
    
        public Data1() {
            refvar = new List<RefStringFunc>() {
                () => ref variable0,
                () => ref variable1,
                () => ref variable2,
                () => ref variable3,
                () => ref variable4,
                () => ref variable5,
                () => ref variable6,
                () => ref variable7,
                () => ref variable8,
                () => ref variable9,
                () => ref variable10,
            };
        }
    
        public ref string this[int index]
        {
            get
            {
                return ref refvar[index]();
            }
        }
    }
