    Public Sub Tick()
        Dim condition1 As Boolean
        Dim condition2 As Boolean
        Dim testNumber As Integer
        If condition1 = true Then
           Tick_Condition1();
           return;
        EndIf
        If condition2 = true Then
           Tick_Condition2();
           return;
        EndIf
        Tick_Switch(testNumber);
