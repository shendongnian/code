        Public Property CustomerTyper As CustomerTypeEnum
            Get
                Return _customerType
            End Get
            Set(value As ActivityActionByEnum)
                SetEnumProperty("CustomerType", _customerType, value)
            End Set
        End Property
