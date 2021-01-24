    Public Class BladeCalibrationSettings
        Inherits XmlSettings
        <XmlElement>
        Public Property BladeName As String
        <XmlElement> 
        Public Property OtherSettings As Whatever
    End Class
    Public Class EngineCalibrationSettings
        Inherits XmlSettings
        <XmlElement>
        Public Property EngineName As String
        <XmlElement> 
        Public Property OtherSettings As Whatever
    End Class
