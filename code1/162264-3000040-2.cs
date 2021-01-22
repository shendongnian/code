    Public Interface IActivity ' this can even be in C# ' 
      ReadOnly Property OccurredOn() As DateTime
    End Interface
    
    Public Class Task
      Implements IActivity
  
      Public ReadOnly Property AssignedOn() As DateTime Implements IActivity.OccurredOn
        Get
          ' implementation... '
        End Get
      End Property
    
    End Class
    
    Public Class Message
      Implements IActivity
  
      Public ReadOnly Property CreatedOn() As DateTime Implements IActivity.OccurredOn
        Get
          ' implementation... '
        End Get
      End Property
    
    End Class
