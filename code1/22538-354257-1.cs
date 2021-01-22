    Function ReturnSomething(Of T)() As T
        return default(T);
    End Function
    Function DoSomething(Of T)()
        Dim x as T = Nothing;
        If x Is Nothing Then
            Console.WriteLine("x is default.");
        Else
            Console.WriteLine("x has a value.");
        End If
    End Function
