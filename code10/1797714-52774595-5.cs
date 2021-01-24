    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class Class1
    {
        public void DoNothingOnClass2Typed()
            => new Class2().DoNothing();
        public void CreateClass2aFromClass2Typed()
            => new Class2().CreateClass2a();
    }
   
