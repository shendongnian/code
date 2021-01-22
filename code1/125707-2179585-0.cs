        ' -------------------------------------------------------------------------
        ' Extract WinForms Designer File Visual Studio 2005/2008 Macro
        ' -------------------------------------------------------------------------
        ' Extracts the InitializeComponent() and Dispose() methods and control
        ' field delarations from a .NET 1.x VS 2003 project into a VS 2005/8 
        ' style .NET 2.0 partial class in a *.Designer.cs file. (Currently C# 
        ' only)
        ' 
        ' To use: 
        '  * Copy the methods below into a Visual Studio Macro Module (use 
        '    ALT+F11 to show the Macro editor)
        '  * Select a Windows Form in the Solution Explorer
        '  * Run the macro by showing the Macro Explorer (ALT+F8) and double
        '    clicking the 'ExtractWinFormsDesignerFile' macro.
        '  * You will then be prompted to manually make the Form class partial: 
        '    i.e. change "public class MyForm : Form"
        '          to
        '             "public partial class MyForm : Form"
        '
        ' Duncan Smart, InfoBasis, 2007
        ' -------------------------------------------------------------------------
    
        Sub ExtractWinFormsDesignerFile()
            Dim item As ProjectItem = DTE.SelectedItems.Item(1).ProjectItem
            Dim fileName As String = item.FileNames(1)
            Dim dir As String = System.IO.Path.GetDirectoryName(fileName)
            Dim bareName As String = System.IO.Path.GetFileNameWithoutExtension(fileName)
            Dim newItemPath As String = dir & "\" & bareName & ".Designer.cs"
    
            Dim codeClass As CodeClass = findClass(item.FileCodeModel.CodeElements)
            Dim namespaceName As String = codeClass.Namespace.FullName
    
            On Error Resume Next ' Forgive me :-)
            Dim initComponentText As String = extractMember(codeClass.Members.Item("InitializeComponent"))
            Dim disposeText As String = extractMember(codeClass.Members.Item("Dispose"))
            Dim fieldDecls As String = extractWinFormsFields(codeClass)
            On Error GoTo 0
    
            System.IO.File.WriteAllText(newItemPath, "" _
              & "using System;" & vbCrLf _
              & "using System.Windows.Forms;" & vbCrLf _
              & "using System.Drawing;" & vbCrLf _
              & "using System.ComponentModel;" & vbCrLf _
              & "using System.Collections;" & vbCrLf _
              & "" & vbCrLf _
              & "namespace " & namespaceName & vbCrLf _
              & "{" & vbCrLf _
              & "	public partial class " & codeClass.Name & vbCrLf _
              & "	{" & vbCrLf _
              & "		#region Windows Form Designer generated code" & vbCrLf _
              & "		" & fieldDecls & vbCrLf _
              & "		" & initComponentText & vbCrLf _
              & "		#endregion" & vbCrLf & vbCrLf _
              & "		" & disposeText & vbCrLf _
              & "	}" & vbCrLf _
              & "}" & vbCrLf _
              )
            Dim newProjItem As ProjectItem = item.ProjectItems.AddFromFile(newItemPath)
            On Error Resume Next
            newProjItem.Open()
            DTE.ExecuteCommand("Edit.FormatDocument")
            On Error GoTo 0
    
            MsgBox("TODO: change your class from:" + vbCrLf + _
                   "  ""public class " + codeClass.FullName + " : Form""" + vbCrLf + _
                   "to:" + _
                   "  ""public partial class " + codeClass.FullName + " : Form""")
        End Sub
    
        Function findClass(ByVal items As System.Collections.IEnumerable) As CodeClass
            For Each codeEl As CodeElement In items
                If codeEl.Kind = vsCMElement.vsCMElementClass Then
                    Return codeEl
                ElseIf codeEl.Children.Count > 0 Then
                    Dim cls As CodeClass = findClass(codeEl.Children)
                    If cls IsNot Nothing Then
                        Return findClass(codeEl.Children)
                    End If
                End If
            Next
            Return Nothing
        End Function
    
        Function extractWinFormsFields(ByVal codeClass As CodeClass) As String
    
            Dim fieldsCode As New System.Text.StringBuilder
    
            For Each member As CodeElement In codeClass.Members
                If member.Kind = vsCMElement.vsCMElementVariable Then
                    Dim field As CodeVariable = member
                    If field.Type.TypeKind <> vsCMTypeRef.vsCMTypeRefArray Then
                        Dim fieldType As CodeType = field.Type.CodeType
                        Dim isControl As Boolean = fieldType.Namespace.FullName.StartsWith("System.Windows.Forms") _
                           OrElse fieldType.IsDerivedFrom("System.Windows.Forms.Control") _
                           OrElse fieldType.IsDerivedFrom("System.ComponentModel.Container")
                        If isControl Then
                            fieldsCode.AppendLine(extractMember(field))
                        End If
                    End If
                End If
            Next
            Return fieldsCode.ToString()
        End Function
    
        Function extractMember(ByVal memberElement As CodeElement) As String
            Dim memberStart As EditPoint = memberElement.GetStartPoint().CreateEditPoint()
            Dim memberText As String = String.Empty
            memberText += memberStart.GetText(memberElement.GetEndPoint())
            memberStart.Delete(memberElement.GetEndPoint())
            Return memberText
        End Function
