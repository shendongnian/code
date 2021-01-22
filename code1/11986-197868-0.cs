        Sub AllCodeToDesktop()
           'The reference for the FileSystemObject Object is Windows Script Host Object Model
           'but it not necessary to add the reference for this procedure.
            
           Dim fs As Object
           Dim f As Object
           Dim strMod As String
           Dim mdl As Object
           Dim i As Integer
            
           Set fs = CreateObject("Scripting.FileSystemObject")
           
           'Set up the file.
           Set f = fs.CreateTextFile(SpFolder("Desktop") & "\" _
             & Replace(CurrentProject.Name, ".", "") & ".txt")
           
           'For each component in the project ...
           For Each mdl In VBE.ActiveVBProject.VBComponents
               'using the count of lines ...
               i = VBE.ActiveVBProject.VBComponents(mdl.Name).CodeModule.CountOfLines
               'put the code in a string ...
               If VBE.ActiveVBProject.VBComponents(mdl.Name).codemodule.CountOfLines > 0 Then
                  strMod = VBE.ActiveVBProject.VBComponents(mdl.Name).codemodule.Lines(1, i)
               End If
               'and then write it to a file, first marking the start with
               'some equal signs and the component name.
               f.writeline String(15, "=") & vbCrLf & mdl.Name _
                   & vbCrLf & String(15, "=") & vbCrLf & strMod
           Next
           
           'Close eveything
           f.Close
           Set fs = Nothing
       End Sub
       Function SpFolder(SpName As String)
       'Special folders
           SpFolder = CreateObject("WScript.Shell").SpecialFolders(SpName)
       End Function  
