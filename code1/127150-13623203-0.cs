     <Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Bericht", DbType:="VarBinary(MAX)", UpdateCheck:=UpdateCheck.Never),
        System.Xml.Serialization.XmlIgnore> _
        Public Property Bericht() As System.Data.Linq.Binary
            Get
                Return Me._Bericht.Value
            End Get
            Set(value As System.Data.Linq.Binary)
                If (Object.Equals(Me._Bericht.Value, Value) = False) Then
                    Me.OnBerichtChanging(Value)
                    Me.SendPropertyChanging()
                    Me._Bericht.Value = Value
                    Me.SendPropertyChanged("Bericht")
                    Me.OnBerichtChanged()
                End If
            End Set
        End Property
