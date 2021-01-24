    public class MyNewClass : BaseClass
    {
        public int? ExtraProperty { get; set; }
        public MyNewClass(BaseClass baseClass)
        {
            BaseProperty1 = baseClass.BaseProperty1;
            BaseProperty2 = baseClass.BaseProperty2;
            BaseProperty3 = baseClass.BaseProperty3;
        }
    }
