    ReadOnly Property BaseProperties As ISingleShot
    Public ReadOnly Property BaseProperties As IBaseClass Implements IClass.BaseProperties
      Get
        Return Me
      End Get
    End Property
