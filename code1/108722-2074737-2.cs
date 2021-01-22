    using System.Text.RegularExpressions;
    
    public class Hello1
    {
       public static void Main()
       {
    
          // Count to 128 in unary
          string numbers = "x\n";
          numbers += Regex.Replace(numbers, "x+\n", "x$&");
          numbers += Regex.Replace(numbers, "x+\n", "xx$&");
          numbers += Regex.Replace(numbers, "x+\n", "xxxx$&");
          numbers += Regex.Replace(numbers, "x+\n", "xxxxxxxx$&");
          numbers += Regex.Replace(numbers, "x+\n", "xxxxxxxxxxxxxxxx$&");
          numbers += Regex.Replace(numbers, "x+\n", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx$&");
          numbers += Regex.Replace(numbers, "x+\n", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx$&");
    
          // Out of 1..128, select 1..100
          numbers = Regex.Match(numbers, "(.*\n){100}").Value;
    
          // Convert from unary to decimal
          numbers = Regex.Replace(numbers, "x{10}", "<10>");
          numbers = Regex.Replace(numbers, "x{9}", "<9>");
          numbers = Regex.Replace(numbers, "x{8}", "<8>");
          numbers = Regex.Replace(numbers, "x{7}", "<7>");
          numbers = Regex.Replace(numbers, "x{6}", "<6>");
          numbers = Regex.Replace(numbers, "x{5}", "<5>");
          numbers = Regex.Replace(numbers, "x{4}", "<4>");
          numbers = Regex.Replace(numbers, "x{3}", "<3>");
          numbers = Regex.Replace(numbers, "x{2}", "<2>");
          numbers = Regex.Replace(numbers, "x{1}", "<1>");
          numbers = Regex.Replace(numbers, "(<10>){10}", "<100>");
          numbers = Regex.Replace(numbers, "(<10>){9}", "<90>");
          numbers = Regex.Replace(numbers, "(<10>){8}", "<80>");
          numbers = Regex.Replace(numbers, "(<10>){7}", "<70>");
          numbers = Regex.Replace(numbers, "(<10>){6}", "<60>");
          numbers = Regex.Replace(numbers, "(<10>){5}", "<50>");
          numbers = Regex.Replace(numbers, "(<10>){4}", "<40>");
          numbers = Regex.Replace(numbers, "(<10>){3}", "<30>");
          numbers = Regex.Replace(numbers, "(<10>){2}", "<20>");
          numbers = Regex.Replace(numbers, "(<[0-9]{3}>)$", "$1<00>");
          numbers = Regex.Replace(numbers, "(<[0-9]{2}>)$", "$1<0>");
          numbers = Regex.Replace(numbers, "<([0-9]0)>\n", "$1\n");
          numbers = Regex.Replace(numbers, "<([0-9])0*>", "$1");
    
          System.Console.WriteLine(numbers);
       
       }
    }
