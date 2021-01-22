    Inherits System.Windows.Forms.AxHost
    Public Sub New()
        MyBase.New("{63109182-966B-4e3c-A8B2-8BC4A88D221C}")
    End Sub
    Public Function GetImageFromIPictureDisp(ByVal objImage As stdole.IPictureDisp) As System.Drawing.Image
        Dim objPicture As System.Drawing.Image
        objPicture = CType(MyBase.GetPictureFromIPicture(objImage), System.Drawing.Image)
        Return objPicture
    End Function
