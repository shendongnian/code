     class TypeTest
     {
         int m_parameter;
         public TypeTest()
         {
         }
         public TypeTest(int parameter)
         {
             m_parameter = parameter;
         }
         public int Param { get { return m_parameter; } }
    }
    
    //method1 - Using generic CreateInstance
    TypeTest defConstructor = Activator.CreateInstance <TypeTest>();
    
    //method2 - Using GetConstructor
    ConstructorInfo c = typeof(TypeTest).GetConstructor(new Type[] { typeof(int)});
    TypeTest getConstructor = (TypeTest)c.Invoke(new object[] { 6 });
    
    //method3 - Using non-generic CreateInstance
    TypeTest nonDefaultConstructor = (TypeTest)Activator.CreateInstance(typeof(TypeTest), 6);
