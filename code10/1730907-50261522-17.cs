    0:000> !U 000007fe977912b0
    
    Normal JIT generated code
    StackOverflow.Performance.Delegates.Delegates+<>c.<.ctor>b__3_2(System.String)
    Begin 000007fe977912b0, size 4
    W:\dump\DelegateBenchmark\StackOverflow.Performance.Delegates\Delegates.cs @ 14:
    
    000007fe`977912b0 8b4208          mov     eax,dword ptr [rdx+8]
    000007fe`977912b3 c3              ret
    
    0:000> !U 000007fe977e0150
    
    Normal JIT generated code
    DynamicClass.lambda_method(System.Runtime.CompilerServices.Closure, System.String)
    Begin 000007fe977e0150, size 4
    
    000007fe`977e0150 8b4208          mov     eax,dword ptr [rdx+8]
    000007fe`977e0153 c3              ret
