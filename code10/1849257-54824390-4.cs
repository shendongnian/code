    Imports System.Runtime.CompilerServices
    
    Class Window
        Inherits WinForms.Form
    
        Public Sub New()
            Me.Build()
            Me.MinimumSize = New Drawing.Size(320, 200)
        End Sub
    
        Private Sub Build()
            Me.status = New WinForms.TextBox With {
                .Dock = WinForms.DockStyle.Bottom
            }
            Me.checkBoxes = New WinForms.CheckedListBox With {
                .Dock = WinForms.DockStyle.Fill
            }
    
            For i As Integer = 1 To 10
                Me.checkBoxes.Items.Add(Char.ToString(ChrW(("a"c + i))), False)
            Next
    
            Me.checkBoxes.SelectedIndexChanged += Function(sender, e) Me.UpdateCheckedList()
            Me.Controls.Add(Me.checkBoxes)
            Me.Controls.Add(Me.status)
        End Sub
    
        Private Sub UpdateCheckedList()
            Dim strStatus As String = ""
    
            If Me.checkBoxes.ContainsSet(New Integer() {2, 4}) Then
                strStatus += "YES"
            End If
    
            Me.status.Text = strStatus
        End Sub
    
        Private checkBoxes As WinForms.CheckedListBox
        Private status As WinForms.TextBox
    End Class
    
    Module CheckedListBoxExtension
        <Extension()>
        Function ContainsSet(ByVal cbl As WinForms.CheckedListBox, ByVal values As ICollection(Of Integer)) As Boolean
            Dim valueSet = New HashSet(Of Integer)(values)
    
            For Each index As Integer In cbl.CheckedIndices
    
                If valueSet.Contains(index) Then
                    valueSet.Remove(index)
                End If
            Next
    
            Return valueSet.Count = 0
        End Function
    End Module
    
