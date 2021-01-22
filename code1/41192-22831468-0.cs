        Private m_blnIsValueChangedByGui As Boolean = True
        Public Property IsValueChangedByGui() As Boolean
            Get
                Return m_blnIsValueChangedByGui
            End Get
            Set(ByVal value As Boolean)
                m_blnIsValueChangedByGui = value
            End Set
        End Property
        Public Shadows Property Value() As Decimal
            Get
                Return MyBase.Value
            End Get
            Set(ByVal value As Decimal)
                IsValueChangedByGui = False
                If (value > Me.Maximum) Then
                    MyBase.Value = Me.Maximum
                ElseIf (value < Me.Minimum) Then
                    MyBase.Value = Me.Minimum
                Else
                    MyBase.Value = value
                End If
                IsValueChangedByGui = True
            End Set
        End Property
