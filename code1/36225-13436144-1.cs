    Public Shared ReadOnly MDS_AngleLabelRotation_XProperty As DependencyProperty = _
                DependencyProperty.Register("MDS_AxisAngleRotation_X", _
                GetType(Double), GetType(MainDecartsSystem), _
                New PropertyMetadata(MDS_AngleLabelRotation_XDefault, AddressOf MDS_RotationChanged))
        Public Property MDS_AngleLabelRotation_X() As Double
            Get
                Return CType(GetValue(MDS_AngleLabelRotation_XProperty), Double)
            End Get
            Set(ByVal value As Double)
                SetValue(MDS_AngleLabelRotation_XProperty, value)
            End Set
        End Property
