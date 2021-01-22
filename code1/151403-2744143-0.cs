    Private Property System.Collections.IList.Item(ByVal index As Integer) As Object
        Get
            Return Me.Item(index)
        End Get
        Set(ByVal value As Object)
            Me.Item(index) = DirectCast(value, MyObject)
        End Set
    End Property
    Public Default Property Item(ByVal index As Integer) As MyObject
        Get
            Return DirectCast(Me.innerArray.Item(index), MyObject)
        End Get
        Set(ByVal value As MyObject)
            Me.innerArray.Item(index) = value
        End Set
    End Property
