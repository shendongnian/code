    Private _MyCollection As myCollection
    Public Property MyCollection() As myCollection
      Get
         Return _MyCollection.AsReadOnly
      End Get
      Private Set(ByVal value As myCollection)
        _MyCollection = value
      End Set
    End Property
