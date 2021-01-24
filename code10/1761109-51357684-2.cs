      public class MyClass {
        public MyClass(string firstName, string secondName, 
                       int firstValue, int secondValue, 
                       string from) {
          //TODO: Validate arguments here: do you accept null? negative values? etc.
          FirstName = firstName; 
          SecondName = secondName;
          FirstValue = firstValue;
          SecondValue = secondValue;
          From = from; 
        }
        public static MyClass Parse(string csvLine) {
          if (null == csvLine)
            throw new ArgumentNullException("csvLine"); 
          string[] items = csvLine.Split('|');
          try {
            return new MyClass(items[0], items[2],
                               int.Parse(items[4]),int.Parse(items[6]),
                               items[8]);
          }
          catch (Exception e) {
            throw new FormatError("Incorrect CSV format", e); 
          }
        }
        public string ToCsv() {
          return string.Join("|", 
            FirstName, "", SecondName, "", FirstValue, "", SecondValue, "", From);
        };
        //TODO: Put a better names for the properties
        public string FirstName {get; set;}
        public string SecondName {get; set;}
        public int FirstValue {get; set;}
        public int SecondValue {get; set;}
        public string From {get; set;}  
      }
