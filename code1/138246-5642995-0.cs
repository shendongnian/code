        Public Property MyProperty() As Object
            Get
                Return Me._MyProperty
            End Get
            Set(value As Object)
                Me._MyProperty = Nothing
                NotifyOfPropertyChange(Function() MyProperty)
                Me._MyProperty = value
                NotifyOfPropertyChange(Function() MyProperty)
            End Set
        End Property
