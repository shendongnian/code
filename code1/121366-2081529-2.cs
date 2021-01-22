    Private _WorkPhone As Long?
        Public Property [WorkPhone]() As Long?
            Get
                Return _WorkPhone
            End Get
            Set(ByVal value As Long?)
                If Not _workPhone.Equals(value)
                    MyBase.RaisePropertyChanging("WorkPhone")
                    _WorkPhone = value
                    MyBase.MarkDirty()
                    MyBase.RaisePropertyChanged("WorkPhone")
                EndIf
            End Set
        End Property
