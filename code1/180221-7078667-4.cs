    Option Strict On
    Option Explicit On
    Option Infer Off
    Public Class Form1
        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            Dim pb As New PictureBox
            pb.Name = "myPicBox"
            pb.BackColor = Color.Goldenrod
            pb.Size = New Size(100, 100)
            pb.Location = New Point(0, 0)
            Dim tb As New TextBox
            tb.Name = "tbTest"
            pb.Controls.Add(tb)
            Me.Controls.Add(pb)
            Dim textBoxList As New List(Of Control)
            textBoxList = GetAllControls(Of TextBox)(Me)
            Dim sb As New System.Text.StringBuilder
            For index As Integer = 0 To textBoxList.Count - 1
                sb.Append(textBoxList.Item(index).Name & "   Parent = " & textBoxList.Item(index).Parent.Name & System.Environment.NewLine)
            Next
            RichTextBox1.Text = sb.ToString
        End Sub
        Private Function GetAllControls(Of T)(ByVal searchWithin As Control) As List(Of Control)
            Dim returnList As New List(Of Control)
            If searchWithin.HasChildren = True Then
                For Each ctrl As Control In searchWithin.Controls
                    If TypeOf ctrl Is T Then
                        returnList.Add(ctrl)
                    End If
                    returnList.AddRange(GetAllControls(Of T)(ctrl))
                Next
            ElseIf searchWithin.HasChildren = False Then
                For Each ctrl As Control In searchWithin.Controls
                    If TypeOf ctrl Is T Then
                        returnList.Add(ctrl)
                    End If
                    returnList.AddRange(GetAllControls(Of T)(ctrl))
                Next
            End If
            Return returnList
        End Function
    End Class
