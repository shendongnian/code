        private static Type BuildEnum(string[] enumValues, string enumName)
        {
            AssemblyName aName = new AssemblyName("TempAssembly");
            AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly(
                aName, AssemblyBuilderAccess.RunAndSave);
            var eb = ab.DefineDynamicModule(aName.Name, aName.Name + ".dll").DefineEnum(enumName, TypeAttributes.Public, typeof(int));
            for (int i = 0; i < enumValues.Length; i++)
            {
                eb.DefineLiteral(enumValues[i], i);
            }
            return eb.CreateType();
        }
     var myEnum = BuildEnum(new string[] { "aa", "bb", "cc", "dd" }, "Temp");
     var enumValues = Enum.GetValues(myEnum)
