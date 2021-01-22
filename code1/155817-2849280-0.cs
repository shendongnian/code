    // C#
    public static void @elseif(bool isTrue)
    {
        if (isTrue)
            Process1();
        else
            Process2();
    }
    // IL
    .method public hidebysig static void  elseif(bool isTrue) cil managed
    {
      // Code size       15 (0xf)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  brfalse.s  IL_0009
      IL_0003:  call       void elseif.Program::Process1()
      IL_0008:  ret
      IL_0009:  call       void elseif.Program::Process2()
      IL_000e:  ret
    } // end of method Program::elseif
    // C#
    public static void @earlyReturn(bool isTrue)
    {
        if (isTrue)
        {
            Process1();
            return;
        }
        Process2();
    }
    // IL
    .method public hidebysig static void  earlyReturn(bool isTrue) cil managed
    {
      // Code size       15 (0xf)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  brfalse.s  IL_0009
      IL_0003:  call       void elseif.Program::Process1()
      IL_0008:  ret
      IL_0009:  call       void elseif.Program::Process2()
      IL_000e:  ret
    } // end of method Program::earlyReturn
