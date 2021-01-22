    using System;
    using System.Reflection;
    
    class MyClass
    {
        static void Main()
        {
            MyClass t = new MyClass();
            A a = new A();
            C[] c = new C[] {new B()};
            t.Assign(a, "field", c);
        }
    
        void Assign(object obj, string field, object[] value)
        {
            FieldInfo pinfo = obj.GetType().GetField(field);
            Array array = Array.CreateInstance(pinfo.FieldType.GetElementType(), value.Length);
            value.CopyTo(array, 0);
            pinfo.SetValue(obj, array);
        }
    }
    
    class A
    {
        public B[] field;
    }
    
    class B : C { }
    
    class C { }
