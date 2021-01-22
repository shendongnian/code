public static class Monitor
{
  private static List<object> monitoredObjects;
  private static RenderWindow _app;
  public static void Initialize(RenderWindow app)
  {
   monitoredObjects = new List<object>();
  }
  public static void Watch(object o)
  {
   monitoredObjects.Add(o);
   o.PropertyChanged += new EventHandler(monitor_PropertyChanged);
  }
  public static void Unwatch(object o)
  {
   o.PropertyChanged -= new EventHandler(monitor_PropertyChanged);
   monitoredObjects.Remove(o);
  }
  public static monitor_PropertyChanged(object sender, PropertyChangedEventArgs e){
    // Not actual code, I actually draw this in game
    Console.WriteLine(e.SomeValue);
  }
  public static void Draw(RenderWindow app)
  {
                    //Not actual code, I actually draw this in game
   foreach (object o in monitoredObjects)
    Console.WriteLine(o.ToString());
  }
 }
 public class Property
 {
  private object obj;
  private PropertyInfo propertyInfo;
  public object PropObj{
     get{ return this.obj; }
  }
  public override string ToString()
  {
   return propertyInfo.Name + ": " + propertyInfo.GetValue(obj, null).ToString();
  }
  public Property(object o, string property)
  {
   obj = o;
   propertyInfo = o.GetType().GetProperty(property);
  }
 }
