    using System;
    
    class Program {
      static void Main(string[] args) {
        string[] arr = new string[] { "hello", "world" };
        int index = Array.IndexOf(arr, "world");
        // Not:
        //int index = arr.IndexOf("world");
        System.Diagnostics.Debug.Assert(index == 1);
      }
    }
