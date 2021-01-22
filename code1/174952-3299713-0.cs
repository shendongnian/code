    Sub Main()
        Dim arrArgs() A s String = Command.Split(“,”)
        Dim i As Integer
        Console.Write(vbNewLine &amp; vbNewLine)
        If arrArgs(0) &lt;&gt; Nothing Then
            For i = LBound(arrArgs) To UBound(arrArgs)
                Console.Write(“Parameter “ &amp; i &amp; ” is “ &amp; arrArgs(i) &amp; vbNewLine)
            Next
        Else
            Console.Write(“No parameter passed”)
        End If
        Console.Write(vbNewLine &amp; vbNewLine)
    End Sub
