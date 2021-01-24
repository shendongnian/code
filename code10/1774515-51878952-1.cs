    This one is the most difficult to do. First you must declare interface such as:
        public interface IDoInt
        {
            int DoInt(int i, string s);
        }
    You need to declare this interface in another assembly, otherwise you would not be able to use this type from dynamically defined assembly (due to circular reference).
    Then you need to change `Weaver` a bit, to make your `A` type implement this interface:
        private void DefineClass()
        {
            this.typebuilder = this.moduleBuilder.DefineType(
                "A",
                TypeAttributes.Public | TypeAttributes.BeforeFieldInit | TypeAttributes.AnsiClass | TypeAttributes.AutoClass,
                typeof(object),
                new[] { typeof(IDoInt) });
        }
        private void DefineMethod()
        {
            MethodBuilder methodBuilder = this.typebuilder.DefineMethod(
                "DoInt",
                MethodAttributes.Public | MethodAttributes.HideBySig |
                MethodAttributes.NewSlot |  MethodAttributes.Virtual |
                MethodAttributes.Final,
                typeof(int), new[] { typeof(int), typeof(string) });
            // ... rest ot the method is the same ...
            // just add this at the end of the method to implement the IDoInt interface
            this.typebuilder.DefineMethodOverride(methodBuilder, typeof(IDoInt).GetMethod("DoInt"));
        }
        
    Now you can call `DoInt` on `IDoInt` interface:
        var i = Weaver.Weave() as IDoInt;
        var result = i.DoInt(3, "foo");
