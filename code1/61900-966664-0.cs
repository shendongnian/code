    Class Base
        Public Overridable Sub Foo()
            Console.WriteLine("Base")
        End Sub
    
        Public Sub InvokeFoo()
            Me.Foo()
            MyClass.Foo()
        End Sub
    End Class
    
    Class Derived : Inherits Base
        Public Overrides Sub Foo()
            Console.WriteLine("Derived")
        End Sub
    End Class
    
    Dim d As Base = New Derived()
    d.InvokeFoo()
