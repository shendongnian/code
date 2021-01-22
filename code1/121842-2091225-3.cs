    public class Fruit {
      private int calories = 0;
    }
    // ...
    var f = new Fruit();
    Type t = typeof(Fruit);
    // Bind to a field named "calories" on the Fruit type.
    FieldInfo fi = t.GetField("calories",
      BindingFlags.NonPublic | BindingFlags.Instance);
    // Get the value of a field called "calories" on this object.
    Console.WriteLine("Field value is: {0}", fi.GetValue(f));
    // Set calories to 100. (Warning! Will cause runtime errors if types
    // are incompatible -- try using "100" instead of the integer 100, for example.)
    fi.SetValue(f, 100);
    // Show modified value.
    Console.WriteLine("Field value is: {0}", fi.GetValue(f));
