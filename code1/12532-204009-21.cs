    myInstanceOrStaticVariable = new Guid(someString);
In addition, if the value is used as an intermediate value, e.g. an argument to a method call, things are slightly different again. To show all these differences, here's a short test program. It doesn't show the difference between static variables and instance variables: the IL would differ between stfld and stsfld, but that's all.
    using System;
    
    public class Test
    {
        static Guid field;
    
        static void Main() {}
        static void MethodTakingGuid(Guid guid) {}
    
    
        static void ParameterisedCtorAssignToField()
        {
            field = new Guid("");
        }
    
        static void ParameterisedCtorAssignToLocal()
        {
            Guid local = new Guid("");
            // Force the value to be used
            local.ToString();
        }
    
        static void ParameterisedCtorCallMethod()
        {
            MethodTakingGuid(new Guid(""));
        }
    
        static void ParameterlessCtorAssignToField()
        {
            field = new Guid();
        }
    
        static void ParameterlessCtorAssignToLocal()
        {
            Guid local = new Guid();
            // Force the value to be used
            local.ToString();
        }
    
        static void ParameterlessCtorCallMethod()
        {
            MethodTakingGuid(new Guid());
        }
    }
