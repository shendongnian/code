    [Serializable]
    public class MyClass
    {
        public int Age { get; set; }
        public int MyClassB { get; set; }
        
        #region Conditional Serialization
        public bool ShouldSerializeAge() { return age > 0; }
        #endregion
    }
    
    [Serializable]
    public class MyClassB
    {
        public int RandomNumber { get; set; }
    }
