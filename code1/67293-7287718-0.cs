    Dim lines As String() = System.IO.File.ReadAllLines(strCustomerFile)
    Dim pattern As String = ",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))"
    Dim r As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex(pattern)
    Dim custs = From line In lines _
                Let data = r.Split(line) _
                    Select New With {.custnmbr = data(0), _
                                     .custname = data(1)}
    For Each cust In custs
        strCUSTNMBR = Replace(cust.custnmbr, Chr(34), "")
        strCUSTNAME = Replace(cust.custname, Chr(34), "")
    Next
