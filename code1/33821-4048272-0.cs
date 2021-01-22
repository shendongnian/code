    using System;
    using System.Text.RegularExpressions;
    
    namespace CSharpConsoleSandbox {
      class Program {
        public static bool isAdultKeyword(string input) {
          if (input == null || input.Length == 0) {
            return false;
          } else {
            Regex regex = new Regex(@"\b(badword1|badword2|anotherbadword)\b");
            return regex.IsMatch(input);
          }
        }
    
        private static void test(string input) {
          string matchMsg = "NO : ";
          if (isAdultKeyword(input)) {
            matchMsg = "YES: ";
          }
          Console.WriteLine(matchMsg + input);
        }
    
        static void Main(string[] args) {
          // These cases should match
          test("YES badword1");
          test("YES this input should match badword2 ok");
          test("YES this input should match anotherbadword. ok");
    
          // These cases should not match
          test("NO badword5");
          test("NO this input will not matchbadword1 ok");
        }
      }
    }
