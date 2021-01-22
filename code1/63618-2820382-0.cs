    Imports System
    Imports System.Collections.Generic
    Imports System.Reflection
    Imports System.Text
    Imports System.Diagnostics
    Module ClassUtils
        Public Sub CopyProperties(ByVal dst As Object, ByVal src As Object)
            Dim srcProperties() As PropertyInfo = src.GetType.GetProperties
            Dim dstType = dst.GetType
            If srcProperties Is Nothing Or dstType.GetProperties Is Nothing Then
                Return
            End If
            For Each srcProperty As PropertyInfo In srcProperties
                Dim dstProperty As PropertyInfo = dstType.GetProperty(srcProperty.Name)
                If dstProperty IsNot Nothing Then
                    If dstProperty.PropertyType.IsAssignableFrom(srcProperty.PropertyType) = True Then
                        dstProperty.SetValue(dst, srcProperty.GetValue(src, Nothing), Nothing)
                    End If
                End If
            Next
        End Sub
    End Module
    Module Module1
        Class base_class
            Dim _bval As Integer
            Public Property bval() As Integer
                Get
                    Return _bval
                End Get
                Set(ByVal value As Integer)
                    _bval = value
                End Set
            End Property
        End Class
        Class derived_class
            Inherits base_class
            Public _dval As Integer
            Public Property dval() As Integer
                Get
                    Return _dval
                End Get
                Set(ByVal value As Integer)
                    _dval = value
                End Set
            End Property
        End Class
        Sub Main()
            ' NARROWING CONVERSION TEST
            Dim b As New base_class
            b.bval = 10
            Dim d As derived_class
            'd = CType(b, derived_class) ' invalidcast exception 
            'd = DirectCast(b, derived_class) ' invalidcast exception
            'd = TryCast(b, derived_class) ' returns 'nothing' for c
            d = New derived_class
            CopyProperties(d, b)
            d.dval = 20
            Console.WriteLine(b.bval)
            Console.WriteLine(d.bval)
            Console.WriteLine(d.dval)
            Console.ReadLine()
        End Sub
    End Module
