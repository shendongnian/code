    public class YourClass
    {
        //Add below line in your class
        public object this[string propertyName] => GetType().GetProperty(propertyName)?.GetValue(this, null);
        public string SampleProperty { get; set; }
    }
    //And you can get value of any property like this.
    var value = YourClass["SampleProperty"];
