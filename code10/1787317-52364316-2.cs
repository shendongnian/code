      public class Sample1<A, B> {
        // Class declares A and B; method declares T
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
        // Method declares T; A and B are resolved (explict types: string and int)
        private void fa<T>() where T : a<string, int>, new() {
          // Code
        }
      }
      public class Sample4<A> {
        // Class declares A; method declares T; B is resolved (explicit type int)
        private void fa<T>() where T : a<A, int>, new() {
          // Code
        }
      }
