    Public Class Form1
        Private Sub Button1_Click(ByVal sender As System.Object, _
                                  ByVal e As System.EventArgs) _
                                  Handles Button1.Click
            Dim b As New B
            b.Foo(5)   ' A::Foo
            b.Foo(5.0) ' B::Foo
        End Sub
    End Class
    
    Class A
        Sub Foo(ByVal n As Integer)
            MessageBox.Show("A::Foo")
        End Sub
    End Class
    
    Class B
        Inherits A
    
        Overloads Sub Foo(ByVal n As Double)
            MessageBox.Show("B::Foo")
        End Sub
    End Class
