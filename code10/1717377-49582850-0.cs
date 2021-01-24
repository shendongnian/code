    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var testIntance = new Test();
                testIntance.Id = (int)5;
            }
        }
    
        public class Test { public decimal Id { get; set; } }
    }
    //
    // IL of Main method
    //
    .method private hidebysig static 
        void Main (
            string[] args
        ) cil managed 
    {
        // Method begins at RVA 0x2050
        // Code size 17 (0x11)
        .maxstack 8
        IL_0000: newobj instance void ConsoleApp1.Test::.ctor()
        IL_0005: ldc.i4.5
        IL_0006: newobj instance void <b>[mscorlib]System.Decimal::.ctor(int32) - not so implicit for the compiler </b>
        IL_000b: callvirt instance void ConsoleApp1.Test::set_Id(valuetype [mscorlib]System.Decimal)
        IL_0010: ret
    } // e
