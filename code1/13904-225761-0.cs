     public class Foo : IDisposable
      { [ThreadStatic] static Foo _instance = null;
        private Foo() {IsReleased = false;}
        public static Foo Instance
         { get
            { if (_instance == null) _instance = new Foo();
              return _instance;
            }
         }
        public void Release()
         { IsReleased = true;
           Foo._instance = null;
         }
        void IDisposable.Dispose() { Release(); }
        public bool IsReleased { get; private set;}
      }
