    Dim a As Integer? = Nothing
    If a = Nothing Then Console.WriteLine("a = Nothing")
    If a <> Nothing Then Console.WriteLine("a <> Nothing")
    If a Is Nothing Then Console.WriteLine("a Is Nothing")
    If a IsNot Nothing Then Console.WriteLine("a IsNot Nothing")
    'Output:
    'a Is Nothing
