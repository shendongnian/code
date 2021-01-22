    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication2
    {
      class Program
      {
        [System.Runtime.InteropServices.DllImport("msvcrt.dll")]
        public static extern uint _control87(uint a, uint b);
        [System.Runtime.InteropServices.DllImport("msvcrt.dll")]
        public static extern uint _clearfp();
        
        static void Main(string[] args)
        {
          float zero = 0.0f - args.Length; // Want 0.0f. Fool compiler...
          System.Console.WriteLine("zero = " + zero.ToString());
          // A NaN which does not throw exception
          float firstNaN = zero / 0.0f;
          System.Console.WriteLine("firstNaN= " + firstNaN.ToString());
          // Now turn on floating-point exceptions
          uint empty = 0;
          uint cw = _control87(empty, empty); // Debugger halts on this one and complains about false signature, but continue works.
          System.Console.WriteLine(cw.ToString());
          uint MCW_EM = 0x0008001f; // From float.h
          uint _EM_INVALID = 0x00000010; // From float.h (invalid corresponds to NaN
          // See http://www.fortran-2000.com/ArnaudRecipes/CompilerTricks.html#x86_FP
          
          cw &= ~(_EM_INVALID);
          _clearfp(); // Clear floating point error word.
          _control87(cw, MCW_EM); // Debugger halts on this one and complains about false signature, but continue works.      
          System.Console.WriteLine(cw.ToString());
          // A NaN which does throw exception
          float secondNaN = 0;
          try
          {
            // Put as much code here as you like.
            // Enable "break when an exception is thrown" in the debugger
            // for system exceptions to get to the line where it is thrown 
            // before catching it below.
            secondNaN = zero / 0.0f;
          }
          catch (System.Exception ex)
          {
            _clearfp(); // Clear floating point error word.
          }      
          
          System.Console.WriteLine("secondNaN= " + secondNaN.ToString());
        }
      }
    }
