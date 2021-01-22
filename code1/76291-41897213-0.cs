    Imports System.Windows.Forms
    Imports System.Drawing
    Imports System.ComponentModel
    Public Class MyTextBox
        Inherits System.Windows.Forms.TextBox
        Private LastKeyIsNotAlpha As Boolean = True
        Protected Overrides Sub OnKeyPress(e As KeyPressEventArgs)
            If _ProperCasing Then
                Dim c As Char = e.KeyChar
                If Char.IsLetter(c) Then
                    If LastKeyIsNotAlpha Then
                        e.KeyChar = Char.ToUpper(c)
                        LastKeyIsNotAlpha = False
                    End If
                Else
                    LastKeyIsNotAlpha = True
                End If
            End If
            MyBase.OnKeyPress(e)
	End Sub
        Private _ProperCasing As Boolean = False
        <Category("Behavior"), Description("When Enabled ensures for automatic proper casing of string"), Browsable(True)>
        Public Property ProperCasing As Boolean
            Get
                Return _ProperCasing
            End Get
            Set(value As Boolean)
                _ProperCasing = value
            End Set
        End Property
    End Class
