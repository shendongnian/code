    public class Class3
    {
       private Func<string, Class2> _class2Factory;
       public Class3(Func<string, Class2> class2Factory)
       {
            _class2Factory = class2Factory;
       }
       public void GetClass2Instance(string interface1ImplementationToChoose)
       {
           var class2 = _class2Factory(interface1ImplementationToChoose);
       }
    }
