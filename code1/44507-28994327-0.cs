    Public Class DbProperty Inherits System.Attribute
    
        Public Property InitialValue As Object
        Public Sub New(ByVal initialValue As EInitialValue)
           Select Case initialValue
              Case EInitialValue.DateTime_Now
                 Me.InitialValue = System.DateTime.Now
        
              Case EInitialValue.DateTime_Min
                 Me.InitialValue = System.DateTime.MinValue
        
              Case EInitialValue.DateTime_Max
                 Me.InitialValue = System.DateTime.MaxValue
        
           End Select
        
        End Sub
    End Class
