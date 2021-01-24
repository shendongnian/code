    Imports System.Text.RegularExpressions 'At the top of the form class
     Public Class FormName
     Private Sub Tbx_EscuelaElegida_LostFocus(.....
     'DECLARE VARIABLE AND ASSIGN THE TEXTBOX CONTENT TO IT
        Dim TestsVariable As String = TextboxName.text
        'IF IT DOES NOT CONTAIN INTEGERS, SHOW A MESSAGE
        If Not Regex.IsMatch(TestsVariable, "^[0-9 ]+$") Then
            MsgBox("No Decimal Numbers")
        End If
     End sub
    End Class
