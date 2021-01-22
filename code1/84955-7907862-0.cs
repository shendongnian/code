    .class public auto ansi sealed Test.Months extends [mscorlib]System.Enum
    {
      .field public specialname rtspecialname int32 value__
      .field public static literal valuetype Test.Months January = int32(0x00000001)
      .field public static literal valuetype Test.Months February = int32(0x00000002)
      .field public static literal valuetype Test.Months March = int32(0x00000003)
      // ...
     
      .method public hidebysig specialname static valuetype Test.Months 
      op_Increment(valuetype Test.Months m) cil managed
      {
        .maxstack 8
     
    	IL_0000: ldarg.0
    	IL_0001: ldc.i4.s 10
    	IL_0003: add
    	IL_0004: ret
      }
    } // end of class Test.Months
