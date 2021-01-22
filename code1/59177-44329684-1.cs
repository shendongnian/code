    static readonly string[] s_toInject = {
      // alternatively "MyAssembly, PublicKey=0024000004800000... etc."
      "MyAssembly"
    };
    static void Main(string[] args) {
      const string THIRD_PARTY_ASSEMBLY_PATH = @"c:\folder\ThirdPartyAssembly.dll";
       var parameters = new ReaderParameters();
       var asm = ModuleDefinition.ReadModule(INPUT_PATH, parameters);
       foreach (var toInject in s_toInject) {
         var ca = new CustomAttribute(
           asm.Import(typeof(InternalsVisibleToAttribute).GetConstructor(new[] {
                          typeof(string)})));
         ca.ConstructorArguments.Add(new CustomAttributeArgument(asm.TypeSystem.String, toInject));
         asm.Assembly.CustomAttributes.Add(ca);
       }
       asm.Write(@"c:\folder-modified\ThirdPartyAssembly.dll");
       // note if the assembly is strongly-signed you need to resign it like
       // asm.Write(@"c:\folder-modified\ThirdPartyAssembly.dll", new WriterParameters {
       //   StrongNameKeyPair = new StrongNameKeyPair(File.ReadAllBytes(@"c:\MyKey.snk"))
       // });
    }
