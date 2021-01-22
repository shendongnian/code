    using System;
    using System.Dynamic;
    using System.ComponentModel;
    
    class Program {
      static void Main(string[] args) {
        dynamic obj = new ExpandoObject();
        obj.test = 42;     // Add a property
        Console.WriteLine(obj.test);
    
        var inpc = (INotifyPropertyChanged)obj;
        inpc.PropertyChanged += inpc_PropertyChanged;
        obj.test = "foo";
        Console.ReadLine();
      }
    
      static void inpc_PropertyChanged(object sender, PropertyChangedEventArgs e) {
        Console.WriteLine("'{0}' property changed", e.PropertyName);
      }
    
    }
