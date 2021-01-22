    Imports System.Windows.Forms
    Imports System.Drawing
    
    ' Add some custom functionality to the standard Label Class
    Public Class CustomLabel
        Inherits Label
    
        ' Allow bold font for right half of a label 
        ' indicated by the placement of a pipe char '|' in the string (ex. "Hello | World" will make bold 'World'
        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            Dim drawPoint As Point = New Point(0, 0)
            Dim boldDelimiter As Char = "|"c
    
            Dim ary() As String = Me.Text.Split(boldDelimiter)
    
            If ary.Length = 2 Then
                Dim normalFont As Font = Me.Font
                Dim boldFont As Font = New Font(normalFont, FontStyle.Bold)
    
                ' Set TextFormatFlags to no padding so strings are drawn together.
                Dim flags As TextFormatFlags = TextFormatFlags.NoPadding
    
                ' Declare a proposed size with dimensions set to the maximum integer value. https://msdn.microsoft.com/en-us/library/8wafk2kt(v=vs.110).aspx
                Dim proposedSize As Size = New Size(Integer.MaxValue, Integer.MaxValue)
    
                Dim normalSize As Size = TextRenderer.MeasureText(e.Graphics, ary(0), normalFont, proposedSize, flags)
                Dim boldSize As Size = TextRenderer.MeasureText(e.Graphics, ary(1), boldFont, proposedSize, flags)
    
                Dim normalRect As Rectangle = New Rectangle(drawPoint, normalSize)
                Dim boldRect As Rectangle = New Rectangle(normalRect.Right, normalRect.Top, boldSize.Width, boldSize.Height)
    
                
    
                TextRenderer.DrawText(e.Graphics, ary(0), normalFont, normalRect, Me.ForeColor, flags)
                TextRenderer.DrawText(e.Graphics, ary(1), boldFont, boldRect, Me.ForeColor, flags)
    
            Else
                ' Default to base class method
                MyBase.OnPaint(e)
            End If
    
        End Sub
    
    
    End Class
