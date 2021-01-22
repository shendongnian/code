    Public Class MyEditor
        Inherits UITypeEditor
        Public Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As System.IServiceProvider, ByVal value As Object) As Object
            Dim typeRes As ITypeResolutionService = TryCast(provider.GetService(GetType(ITypeResolutionService)), ITypeResolutionService)
            Dim ass As System.Reflection.AssemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName()
            MessageBox.Show(ass.CodeBase, "Design-time Path")
            MessageBox.Show(typeRes.GetPathOfAssembly(ass), "Run-time Path")
        End Function
    End Class
