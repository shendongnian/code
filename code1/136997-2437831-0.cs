    Private _InternalProperty
    Public ReadOnly Property InternalProperty
        Get
            Return Me._ProxyInternalProperty 
        End Get
    End Property
    <Browsable(False), EditorBrowsable(Never), DesignerSerializationVisibility(Content)> _
    Public ReadOnly Property _ProxyInternalProperty
        Get
            Return Me._InternalProperty
        End Get
    End Property
