    Public Class MyControl
       Inherits Control
       ' The base class has [Browsable(true)] applied to the Text property.
       <Browsable(False)>  _
       Public Overrides Property [Text]() As String
          ...
       End Property 
       ...
    End Class
