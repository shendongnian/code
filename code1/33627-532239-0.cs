    Public Interface ISimpleInterface
      ReadOnly Property ErrorMsg() As String
    End Interface
    
    Friend Interface IExtendedInterface
      Property ErrorMsg() As String
      Property SomeOtherProperty() As String
    End Interface
    
    Public Class Foo
      Implements ISimpleInterface, IExtendedInterface
      Private other As String
      Private msg As String
    
      Public Property ErrorMsgEx() As String Implements IExtendedInterface.ErrorMsg
        Get
          Return msg
        End Get
        Set(ByVal value As String)
          msg = value
        End Set
      End Property
    
      Public Property SomeOtherPropertyEx() As String Implements IExtendedInterface.SomeOtherProperty
        Get
          Return other
        End Get
        Set(ByVal value As String)
          other = value
        End Set
      End Property
    
      Public ReadOnly Property ErrorMsg() As String Implements ISimpleInterface.ErrorMsg
        Get
          Return msg
        End Get
      End Property
    End Class
