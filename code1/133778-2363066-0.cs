    Public Class Foo
      Implements IPersistable(Of Integer)
      Private m_Id As Integer
      Public ReadOnly Property Id() As Integer Implements IPersistable(Of Integer).Id
        Get
          Return m_Id
        End Get
      End Property
      Protected Property IdInternal() As Integer
        Get
          Return m_Id
        End Get
        Set(ByVal value As Integer)
          m_Id = value
        End Set
      End Property
    End Class
