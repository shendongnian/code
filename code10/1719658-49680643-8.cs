    var iterations = 1000000000;
    var sum = 0;
    var stp = new Stopwatch();
    stp.Start();
    for (int i = 0; i < iterations; i++)
    {
        sum++;
    }
    stp.Stop();
    
    Console.WriteLine("Single Thread");
    Console.WriteLine($"Sum: {sum}");
    Console.WriteLine($"Time Taken (ms): {stp.ElapsedMilliseconds}");
    
    var sum2 = 0;
    stp.Reset();
    stp.Start();
    Parallel.For(0, iterations, x =>
    {
        sum2++;
    });
    stp.Stop();
    Console.WriteLine("Parallel");
    Console.WriteLine($"Sum: {sum2}");
    Console.WriteLine($"Time Taken (ms): {stp.ElapsedMilliseconds}");
    
    Console.ReadKey(true);
.method private hidebysig static void  Main(string[] args) cil managed
{
  .entrypoint
  // Code size       244 (0xf4)
  .maxstack  4
  .locals init ([0] class Test.Program/'<>c__DisplayClass0_0' 'CS$<>8__locals0',
           [1] int32 iterations,
           [2] int32 sum,
           [3] class [System]System.Diagnostics.Stopwatch stp,
           [4] int32 i,
           [5] bool V_5)
  IL_0000:  newobj     instance void Test.Program/'<>c__DisplayClass0_0'::.ctor()
  IL_0005:  stloc.0
  IL_0006:  nop
  IL_0007:  ldc.i4     0x3b9aca00
  IL_000c:  stloc.1
  IL_000d:  ldc.i4.0
  IL_000e:  stloc.2
  IL_000f:  newobj     instance void [System]System.Diagnostics.Stopwatch::.ctor()
  IL_0014:  stloc.3
  IL_0015:  ldloc.3
  IL_0016:  callvirt   instance void [System]System.Diagnostics.Stopwatch::Start()
  IL_001b:  nop
  IL_001c:  ldc.i4.0
  IL_001d:  stloc.s    i
  IL_001f:  br.s       IL_002d
  IL_0021:  nop
  IL_0022:  ldloc.2
  IL_0023:  ldc.i4.1
  IL_0024:  add
  IL_0025:  stloc.2
  IL_0026:  nop
  IL_0027:  ldloc.s    i
  IL_0029:  ldc.i4.1
  IL_002a:  add
  IL_002b:  stloc.s    i
  IL_002d:  ldloc.s    i
  IL_002f:  ldloc.1
  IL_0030:  clt
  IL_0032:  stloc.s    V_5
  IL_0034:  ldloc.s    V_5
  IL_0036:  brtrue.s   IL_0021
  IL_0038:  ldloc.3
  IL_0039:  callvirt   instance void [System]System.Diagnostics.Stopwatch::Stop()
