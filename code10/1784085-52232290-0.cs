    using System;
    using System.Text;
    using System.Linq;
    class MainClass {
      public static void Main (string[] args) {
        const string testcase = "Please Change 7984";
        const string input = "Please Change 2015";
        var builder = new StringBuilder();
        input.ToList<Char>().ForEach(c => {
            if ('0' <= c && c <= '9')
                builder.Append('9' - c);
            else
                builder.Append(c);
        });
        var output = builder.ToString();
        var success = (testcase == output);
        Console.WriteLine($"output: {output}");
        Console.WriteLine($"success: {success}");
      }
    }
