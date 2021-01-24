    Imports System.Runtime.InteropServices
    Imports System.IO.Compression
    Imports System.IO
    <ClassInterface(ClassInterfaceType.AutoDual)>
    Public Class AlbertCom1
    Private m_Times2 As Integer
    Public Sub MsgHello()
        MsgBox("Hello world", MsgBoxStyle.Information, "VB.net example")
    End Sub
    Public Sub MyZipper(strFileName As String, strZipFile As String)
        Using archive As ZipArchive = ZipFile.Open(strZipFile, ZipArchiveMode.Update)
            archive.CreateEntryFromFile(strFileName, Path.GetFileName(strFileName), CompressionLevel.Fastest)
        End Using
    End Sub
    Public Function GetConValue(strSetting As String) As String
        ' read a simple value from config file
        Return My.Settings(strSetting).ToString
    End Function
    Public Property Times2 As Integer
        Get
            Return m_Times2
        End Get
        Set(value As Integer)
            m_Times2 = value * 2
        End Set
    End Property
    End Class
