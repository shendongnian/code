    namespace MyNamespace {
      public class Test {
        [DllImport("TheNameOfThe.dll")]
        public static extern void CreateMyClassInstance();
        
        public void CallIt() {
            CreateMyClassInstance(); // calls the unmanged function via PInvoke
        }
      }
    }
        
