    class MyType
    {
        public virtual StateEnum State { get; set; }
    }
    
    <class name="MyType">
        <property name="State" type="MyNamespace.MyEnumUserType, MyDll" />
    </class>
