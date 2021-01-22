    class Parent
    {
        public string ParentProperty { get; set; }
        public static T1 Convert<T1>(Parent obj) where T1 : Parent, new()	
        {
        var result = new T1();
        result.ParentProperty = obj.ParentProperty;
        return result;
        }
    }
