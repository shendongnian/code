      public class SomeClass2
      {
        private SomeClass someClass;
        public X x { get { return someClass.x; } }
        public SomeClass2(SomeClass sc)
        {
          someClass = sc;
        }
      }
