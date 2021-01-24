      public class Sample1<A, B> {
        // Class declares A and B, method declares T
        private void fa<T>() where T : a<A, B>, new() {
          // Code
        }
      }
    
      public class Sample2 {
        // Method declares all three generic types: A, B and T
        private void fa<T, A, B>() where T : a<A, B>, new() {
          // Code 
        }
      }
    
      public class Sample3 {
        // T is declared, A and B are resolved (explict types: string and int)
        private void fa<T>() where T : a<string, int>, new() {
          // Code
        }
      }
      // Class declares A
      public class Sample4<A> {
        // Method declares T; B is explicit type (int)
        private void fa<T>() where T : a<A, int>, new() {
          // Code
        }
      }
