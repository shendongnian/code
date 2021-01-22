Public Class IntermediateClassForPrivateInheritanceOnly
  Inherits Parent
  Public Overrides ReadOnly Property Foo() As String
  etc.
  Private Sub New(whatever)
    MyBase.New(whatever)
  End Sub
  
  Most other stuff for the class goes here.
  Public Class ReadWriteChild
    Inherits IntermediateClassForPrivateInheritanceOnly
    Shadows Property Foo()
    etc.
    Public Sub New(whatever)
      MyBase.New(whatever)
    End Sub
  End Class
End Class
Public Class ReadWriteChild  ' Would use an alias, if such things existed
  Inherits IntermediateClassForPrivateInheritanceOnly
  Public Sub New(whatever)
    MyBase.New(whatever)
  End Sub
End Class
