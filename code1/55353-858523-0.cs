    var anObject = new SomeClass {
        InitialSomeThings = new[] {
             1,
             2,
             3,
             4
        }
    }
    class SomeClass {
        private readonly int[] _somethings;
        public int[] 
           get { return _somethings; }
        }
        public int[] InitialSomeThings {
           set { 
               for(int i=0; i<value.Length; i++)
                   _somethings[i] = value[i];
           }
       }
    }
