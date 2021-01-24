    public abstract class BaseClass
    {
        public BaseClass CreateCopy()
        {
            string serialized = JsonConvert.SerializeObject(this);
            var actualType = GetType();
            return JsonConvert.DeserializeObject(serialized, actualType) as BaseClass;
        }
    }
    public class DerivedClass : BaseClass
    {
        public string Property1 { get; set; }
        public int Property2 { get; set; }
        [JsonIgnore]
        public int Property3 { get; set; }
        //parameterless constructor
        public DerivedClass() { }
        public override string ToString()
        {
            return $"{Property1} - {Property2} - {Property3}";
        }
    }
