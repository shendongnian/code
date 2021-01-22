    Private _MyCollection as myCollection = Nothing
    Public Shared ReadOnly Property MyCollection() As myCollection
       Get
          If _MyCollection is Nothing Then _MyCollection = New myCollection
          Return _MyCollection
       End Get
    End Property
