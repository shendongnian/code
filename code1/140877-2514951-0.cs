    abstract class Base
    {
      protected Base()
      {
        var actualtype = GetType();
        foreach (var pi in actualtype.GetProperties())
        {
          foreach (var attr in pi.GetCustomAttributes(
             typeof(MyPropertyAttribute), false))
          {
            var data = GetData(attr.Name); // get data
            pi.SetValue(this, data, null);
          }
        }
      }
    }
