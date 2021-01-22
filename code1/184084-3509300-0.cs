    using System;
     
    public class PluralFormatter : IFormatProvider, ICustomFormatter {
     
       public object GetFormat(Type formatType) {
          if (formatType == typeof(ICustomFormatter))
             return this;
          else
             return null;
       }
     
       public string Format(string format, object arg, 
                              IFormatProvider formatProvider)
       {   
          if (! formatProvider.Equals(this)) return null;
     
          if (! format.StartsWith("^")) return null;
     
          String[] parts = format.Split(new char[] {'^'});
          int choice = ((int) arg) == 1 ? 1 : 2;
          return String.Format("{0} {1}", arg, parts[choice]);
       }
     
       public static void Main() {
          Console.WriteLine(String.Format(
             new PluralFormatter(),
             "{0:^puppy^puppies}, {1:^child^children}, and {2:^kitten^kittens}", 
             13, 1, 42
          ));
       }
    }
