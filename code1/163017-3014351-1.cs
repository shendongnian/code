            Public Overrides ReadOnly Property Attributes() As System.ComponentModel.AttributeCollection
                Get
                    Return New AttributeCollection(New Attribute() {RefreshPropertiesAttribute.Repaint})
                End Get
            End Property
