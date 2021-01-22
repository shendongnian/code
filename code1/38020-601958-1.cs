    .method public hidebysig static void Main(string[] args) cil managed
    {
      .custom instance void [mscorlib]System.STAThreadAttribute::.ctor()
      .maxstack 1
      .locals init (
          [0] string str)
      L_0000: ldstr "This is a really long long long long long long long long long long long long long long long long long  long long long long long long long long long string for example."
      L_0005: stloc.0 
      L_0006: ldloc.0 
      L_0007: call void [mscorlib]System.Console::WriteLine(string)
      L_000c: ret 
    }
