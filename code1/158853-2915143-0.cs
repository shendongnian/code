    Public Property AlternateItemColors() As Boolean Implements AbstractInterfaces.CoreControls.IVisualList.AlternateItemColors
        Get
            Return m_AlternateItemColors
        End Get
        Set(ByVal value As Boolean)
            m_AlternateItemColors = value
        End Set
    End Property
    Public Overridable Function ShouldSerializeAlternateItemColors() As Boolean
        If Me.AlternateItemColors = True Then Return False
        Return True
    End Function
