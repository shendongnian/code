    public MyStructureMap {
    
        public void static InitializeMapping() {
           StructureMap.DSL.Registiry.ForRequestedType<ILog>().TheDefault.Is.OfConcreteType<Log>()
              .WithCtorArg("file").EqualTo(@"C:\tmp\log.txt")
              .WithCtorArg("flag").EqualTo(@"debug");
        }
     ....
    }
