    public enum MyEnum
    {
        FirstWord,
        SecondWord,
        Another = 5
    };
  
    // later in some method  
     StringBuilder sb = new StringBuilder();
     foreach (var val in Enum.GetValues(typeof(MyEnum))) {
       int numberValue = (int)val;
       string friendyName = val.ToString();
       sb.Append("Enum number " + numberValue + " has the name " + friendyName + "\n");
     }
     File.WriteAllText(@"C:\temp\myfile.txt", sb.ToString());
     // Produces the output file contents:
     /*
     Enum number 0 has the name FirstWord
     Enum number 1 has the name SecondWord
     Enum number 5 has the name Another
     */
