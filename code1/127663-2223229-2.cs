    Class MyRewritten
        ...
        Implements IUnknown
        Implements ILegacy
        ...
        Sub IUnknown_AddRef()
            c = c + 1
        End Sub
    
        Sub IUnknown_Release()
            c = c - 1
            If c = 0 Then
                RaiseEvent Me.Class_Terminate
                Erase Me
            End If
        End Sub
