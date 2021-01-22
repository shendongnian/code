    '*************************************************************************
    '   Class: MsgFile
    '  Author: Ron Savage
    '    Date: 05/14/2009
    '
    ' This class is an example for using an XML file to hold messages to be
    ' displayed by an application.
    '
    ' Modification History
    ' Date        Init Comment
    ' 05/14/2009  RS   Created.
    '*************************************************************************
    Imports Microsoft.VisualBasic
    Imports System.IO
    
    Public Class MsgFile
       '*************************************************************************
       ' Class Variables
       '*************************************************************************
       Private MsgFile As String
       Private msgData As DataSet
       Private msgTable As DataTable
    
       '*************************************************************************
       '     Sub: New()
       '  Author: Ron Savage
       '    Date: 05/14/2009
       '
       ' Creates a new MsgFile from an existing file, or creates an empty one
       ' with the specified file name.
       '*************************************************************************
       Sub New(ByVal msg_File As String)
          Dim srcFile As New FileInfo(msg_File)
    
          If (srcFile.Exists()) Then
             msgData = New DataSet()
    
             Load(msg_File)
          Else
             NewFile(msg_File)
          End If
       End Sub
    
       '*************************************************************************
       '     Sub: NewFile()
       '  Author: Ron Savage
       '    Date: 05/14/2009
       '
       ' Creates a new XML message file.
       '*************************************************************************
       Sub NewFile(ByVal msg_File As String)
          Me.MsgFile = msg_File
    
          If (IsNothing(msgData)) Then
             msgData = New DataSet("MyAppMessages")
             msgTable = New DataTable("Messages")
    
             msgTable.Columns.Add(New DataColumn("Id", GetType(System.Int32), Nothing, MappingType.Attribute))
             msgTable.Columns.Add(New DataColumn("Text", GetType(System.String), Nothing, MappingType.Attribute))
    
             msgData.Tables.Add(msgTable)
    
             setMessage(0, "New file created")
          End If
    
          Save()
       End Sub
    
       '*************************************************************************
       '     Sub: Load()
       '  Author: Ron Savage
       '    Date: 05/14/2009
       '
       ' Loads an existing XML message file into the dataset.
       '*************************************************************************
       Public Sub Load(ByVal msgFileName As String)
          Dim srcFile As FileInfo = Nothing
          Me.MsgFile = msgFileName
    
          srcFile = New FileInfo(msgFileName)
    
          msgData.Clear()
    
          If (srcFile.Exists()) Then
             msgData.ReadXml(msgFileName)
    
             msgTable = msgData.Tables("Messages")
          End If
       End Sub
    
       '*************************************************************************
       '     Sub: Save()
       '  Author: Ron Savage
       '    Date: 10/05/2008
       '
       ' This routine saves the DataSet to an XML file.
       '*************************************************************************
       Public Overridable Sub Save()
          If (Not IsNothing(msgData) And Not MsgFile.Equals("")) Then
             Dim fileWriter As StreamWriter = New StreamWriter(MsgFile)
    
    
             msgData.WriteXml(fileWriter)
    
             fileWriter.Close()
          End If
       End Sub
    
       '*************************************************************************
       '     Sub: getMessage()
       '  Author: Ron Savage
       '    Date: 05/14/2009
       '
       ' This gets the text of the message.
       '*************************************************************************
       Public Function getMessage(ByVal msgId As String) As String
          Dim rowsFound() As System.Data.DataRow
          Dim msgText As String = ""
    
          If (Not IsNothing(msgTable)) Then
             rowsFound = msgTable.Select("Id = " + msgId.ToString)
    
             If (rowsFound.Length > 0) Then
                msgText = rowsFound(0).Item("Text").ToString
             End If
    
          End If
          Return (msgText)
       End Function
    
       '*************************************************************************
       '     Sub: setMessage()
       '  Author: Ron Savage
       '    Date: 05/14/2009
       '
       ' This sets the text of the message.
       '*************************************************************************
       Public Sub setMessage(ByVal msgId As Integer, ByVal msgText As String)
          Dim rowsFound() As System.Data.DataRow
          Dim msgRow As System.Data.DataRow
    
          If (Not IsNothing(msgTable)) Then
             rowsFound = msgTable.Select("Id = " + msgId.ToString)
    
             If (rowsFound.Length > 0) Then
                msgRow = rowsFound(0)
    
                msgRow.Item("Id") = msgId
                msgRow.Item("Text") = msgText
             Else
                msgRow = msgTable.NewRow()
    
                msgRow.Item("Id") = msgId
                msgRow.Item("Text") = msgText
    
                msgTable.Rows.Add(msgRow)
             End If
          End If
    
          Save()
       End Sub
    End Class
