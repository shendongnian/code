    Imports System
    Imports Microsoft.Win32
    Public Class OpenFileDialogEx
        Public Shared ReadOnly FilterProperty As DependencyProperty = DependencyProperty.RegisterAttached("Filter", GetType(String), GetType(OpenFileDialogEx), New PropertyMetadata("All documents (.*)|*.*", Sub(d, e) AttachFileDialog(DirectCast(d, TextBox), e)))
    Public Shared Function GetFilter(element As UIElement) As String
        Return DirectCast(element.GetValue(FilterProperty), String)
    End Function
    Public Shared Sub SetFilter(element As UIElement, value As String)
        element.SetValue(FilterProperty, value)
    End Sub
    Private Shared Sub AttachFileDialog(textBox As TextBox, args As DependencyPropertyChangedEventArgs)
        Dim parent = DirectCast(textBox.Parent, Panel)
        AddHandler parent.Loaded, Sub()
                                      Dim button = DirectCast(parent.Children.Cast(Of Object)().FirstOrDefault(Function(x) TypeOf x Is Button), Button)
                                      Dim filter = DirectCast(args.NewValue, String)
                                      AddHandler button.Click, Sub(s, e)
                                                                   Dim dlg = New OpenFileDialog()
                                                                   dlg.Filter = filter
                                                                   Dim result = dlg.ShowDialog()
                                                                   If result = True Then
                                                                       textBox.Text = dlg.FileName
                                                                   End If
                                                               End Sub
                                  End Sub
    End Sub
