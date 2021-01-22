    using System;
    using System.Linq;
    using System.ComponentModel;
    using System.Linq.Expressions;
    namespace OnNotifyUsingLambda
    {
        public class MainClass : INotifyPropertyChanged
        {
             public static void Main (string[] args) { new MainClass().Run();}
             public void Run()
             {
                  this.PropertyChanged += (sender, e) => Console.WriteLine(e.PropertyName);
                  MyProperty = "Hello";
             }
 
             private string myProperty;
             public string MyProperty  
             {
                 get
                 {
                     return myProperty;
                 }
                 set
                 {
                     myProperty = value;
                     // call our OnPropertyChanged with our lamba expression, passing ourselves.
                     // voila compile time checking that we haven't messed up!
                     OnPropertyChanged((mainClass) => mainClass.MyProperty); 
                  }
             }  
  
             /// <summary>
             /// Fires the PropertyChanged for a property on our class.
             /// </summary>
             /// <param name="property">
             /// A <see cref="Expression<Func<MainClass, System.Object>>"/> that contains the 
             /// property we want to raise the event for.
             /// </param>
             private void OnPropertyChanged (Expression<Func<MainClass, object>> property)
             {
                 // pull out the member expression (ie mainClass.MyProperty)
                 var expr = (MemberExpression)property.Body; 
  
                 if (PropertyChanged != null)
                 {
                     // Extract everything after the period, which is our property name.
                     var propName = expr.ToString ().Split (new[] { '.' })[1];
                     PropertyChanged (this, new PropertyChangedEventArgs(propName));
                 }
              }
              public event PropertyChangedEventHandler PropertyChanged;
         }
    }
