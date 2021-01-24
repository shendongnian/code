    scriptcs (ctrl-c to exit or :help for help)
    
    > using System.Reflection;
    >
    > public class HasChangedBase
    * {
    *     private class PropertyState
    *     {
    *         public PropertyInfo Property {get;set;}
    *         public Object Value {get;set;}
    *     }
    *
    *     private Dictionary<string, PropertyState> propertyStore;
    *
    *     public void SaveState()
    *     {
    *         propertyStore = this
    *             .GetType()
    *             .GetProperties()
    *             .ToDictionary(p=>p.Name, p=>new PropertyState{Property = p, Value = p.GetValue(this)});
    *     }
    *
    *     public bool HasChanged(string propertyName)
    *     {
    *         return propertyStore != null
    *             && propertyStore.ContainsKey(propertyName)
    *             && propertyStore[propertyName].Value != propertyStore[propertyName].Property.GetValue(this);
    *     }
    * }
    >
    > public class POCO : HasChangedBase
    * {
    *     public string Prop1 {get;set;}
    *     public string Prop2 {get;set;}
    * }
    >
    > var poco = new POCO();
    > poco.Prop1 = "a";
    a
    > poco.Prop2 = "B";
    B
    >
    >
    > poco.SaveState();
    > poco.Prop2 = "b";
    b
    > poco.HasChanged("Prop1");
    False
    > poco.HasChanged("Prop2");
    True
