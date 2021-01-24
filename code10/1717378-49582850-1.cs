    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var a = 5;
                Test(a);
            }
            
            static void Test(decimal number) { }
        }
    }
    //
    // IL of the main method
    //
    .method private hidebysig static 
        void Main (
            string[] args
        ) cil managed 
    {
        // Method begins at RVA 0x2050
        // Code size 12 (0xc)
        .maxstack 8
        IL_0000: ldc.i4.5
        IL_0001: call valuetype [mscorlib]System.Decimal [mscorlib]<b>System.Decimal::op_Implicit(int32)</b>
        IL_0006: call void ConsoleApp1.Program::Test(valuetype [mscorlib]System.Decimal)
        IL_000b: ret
    } // end of method Program::Main
