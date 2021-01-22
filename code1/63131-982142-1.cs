    class ParamType   {    }
    class DerivedParamType : ParamType    {    }
    class TypeToCreate
    {
        public TypeToCreate(DerivedParamType data)
        {
            // do something
        }
    }
    ParamType args = new ParamType();
    // this call will fail: "constructor not found"
    object obj = Activator.CreateInstance(typeof(TypeToCreate), new object[] { args });
    // this call would work, since the input type matches the constructor
    DerivedParamType args = new DerivedParamType();
    object obj = Activator.CreateInstance(typeof(TypeToCreate), new object[] { args });
