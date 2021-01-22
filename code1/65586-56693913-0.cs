<Import Project="$(MSBuildToolsPath)\Microsoft.VisualBasic.targets" />
Code to paste
<Target Name="AfterResolveReferences">
   <ItemGroup>
      <EmbeddedResource Include="@(ReferenceCopyLocalPaths)" Condition="'%(ReferenceCopyLocalPaths.Extension)' == '.dll'">
         <LogicalName>%(ReferenceCopyLocalPaths.DestinationSubDirectory)%(ReferenceCopyLocalPaths.Filename)%(ReferenceCopyLocalPaths.Extension)
         </LogicalName>
      </EmbeddedResource>
   </ItemGroup>
</Target>
4.	Close it, save it, and then reload the project
5.	In the Application.xaml.vb file add the following code, or if something already exists in the file, add this to it:
Imports System.Reflection
Imports System.Globalization
Imports System.IO
Class Application
    Public Sub New()
        AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf OnResolveAssembly
    End Sub
    Private Shared Function OnResolveAssembly(ByVal sender As Object, ByVal args As ResolveEventArgs) As Assembly
        Dim executingAssembly As Assembly = Assembly.GetExecutingAssembly()
        Dim assemblyName As AssemblyName = New AssemblyName(args.Name)
        Dim path = assemblyName.Name & ".dll"
        If assemblyName.CultureInfo.Equals(CultureInfo.InvariantCulture) = False Then path = String.Format("{0}\{1}", assemblyName.CultureInfo, path)
        Using stream As Stream = executingAssembly.GetManifestResourceStream(path)
            If stream Is Nothing Then Return Nothing
            Dim assemblyRawBytes = New Byte(stream.Length - 1) {}
            stream.Read(assemblyRawBytes, 0, assemblyRawBytes.Length)
            Return Assembly.Load(assemblyRawBytes)
        End Using
    End Function
End Class
