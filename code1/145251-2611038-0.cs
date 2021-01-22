	using System;
	using System.Collections;
	public class ExampleClass
	{
	   public sealed class Path
	   {
	      private Path(){}
	      private static char[] badChars = {'\"', '<', '>'};
	      public static char[] GetInvalidPathChars()
	      {
	         return badChars;
	      }
	   }
	   public static void Main()
	   {
	      // The following code displays the elements of the 
	      // array as expected.
	      foreach(char c in Path.GetInvalidPathChars())
	      {
	         Console.Write(c);
	      }
	      Console.WriteLine();
	      // The following code sets all the values to A.
	      Path.GetInvalidPathChars()[0] = 'A';
	      Path.GetInvalidPathChars()[1] = 'A';
	      Path.GetInvalidPathChars()[2] = 'A';
	      // The following code displays the elements of the array to the
	      // console. Note that the values have changed.
	      foreach(char c in Path.GetInvalidPathChars())
	      {
	         Console.Write(c);
	      }
	   }
	}
