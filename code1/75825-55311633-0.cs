    // base object
    public abstract class BaseObject
    {
        public int ID { get; set; } = 0;
        public string SomeText { get; set; } = "";
        public DateTime? CreatedDateTime { get; set; } = DateTime.Now;
        public string AnotherString { get; set; } = "";
        public bool aBoolean { get; set; } = false;
        public int integerForSomething { get; set; } = 0;
    }
    // derived object
    public class CustomObject : BaseObject
    {
        public string ANewProperty { get; set; } = "";
        public bool ExtraBooleanField { get; set; } = false;
        
        //Set base object properties in the constructor
        public CustomObject(BaseObject source)
        {
            var properties = source.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            
            foreach(var fi in properties)
            {
                fi.SetValue(this, fi.GetValue(source));
            }
        }
    }
