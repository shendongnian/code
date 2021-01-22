    public class Example_Class
    {    // snip
         // all properties are public get and private set
        
         private Dictionary<string, Delegate> m_PropertySetterMap;
                
         public Example_Class()
         {
            m_PropertySetterMap = new Dictionary<string, Delegate>();
            InitializeSettableProperties();
         }
         public Example_Class(long id, string name):this()
         {   this.ID = id;    this.Name = name;   }
    
         private void InitializeSettableProperties()
         {
            AddToPropertyMap<long>("ID",  value => { this.ID = value; });
            AddToPropertyMap<string>("Name", value => { this.Name = value; }); 
         }
         // jump thru a hoop because it won't let me cast an anonymous method to an Action<T>/Delegate
         private void AddToPropertyMap<T>(string sPropertyName, Action<T> setterAction)
         {   m_PropertySetterMap.Add(sPropertyName, setterAction);            }
        
         public void SetProperty<T>(string propertyName, T value)
         {
            (m_PropertySetterMap[propertyName] as Action<T>).Invoke(value);
            this.Status = StatusEnum.Dirty;
         }
      }
