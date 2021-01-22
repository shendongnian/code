    Public Sub Tick()
        Dim condition1 As Boolean
        Dim condition2 As Boolean
        Dim testNumber As Integer
    
        If basecase = True Then
           return;
        EndIf
    
        ExecuteInitialzerStuff();
    
        If intialized = False Then
            Tick();
            return;
        Else
            ExecuteAffirmationStuff();
        End If
    
        If affirmed = True Then
            ExecutePostAffirm();
            Tick();
            return;
        End If
    
        Select Case testNumber
            Case 4: Tick();
        End Select
    End Sub
