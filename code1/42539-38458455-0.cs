    Function ColumnbyName(vInput As Variant, Optional bByName As Boolean = True) As Variant
        Dim Rng As Range
        If bByName Then
           If Not VBA.IsNumeric(vInput) Then
                Set Rng = ThisWorkbook.Worksheets("mytab").Range(vInput & "1:" & vInput & "1")
                ColumnbyName = Rng.Column
           Else
                MsgBox "Please enter valid non Numeric column or change paramter bByName to False!"
           End If
           
        Else
            If VBA.IsNumeric(vInput) Then
                ColumnbyName = VBA.Chr(64 + CInt(vInput))
            Else
                MsgBox "Please enter valid Numeric column or change paramter bByName to True!"
            End If
                
        End If
    End Function
