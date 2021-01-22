    Imports System.ComponentModel
    Imports System.Web.UI
    Imports Microsoft.VisualBasic
    Imports System.IO
    Namespace CustomControls
    <ToolboxData("<{0}:GridViewColGroup runat=server></{0}:GridViewColGroup>")> _
    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust"), _
    ParseChildren(True)> _
    Public Class GridViewColGroup
        Inherits GridView
        Implements INamingContainer
        Private _ColGroup As ColGroup = Nothing
        Private _ColGroupTemplate As ITemplate = Nothing
        <Browsable(False), _
        Description("The ColGroup template."), _
        TemplateContainer(GetType(ColGroup)), _
        PersistenceMode(PersistenceMode.InnerProperty)> _
        Public Overridable Property ColGroupTemplate() As ITemplate
            Get
                Return _ColGroupTemplate
            End Get
            Set(ByVal value As ITemplate)
                _ColGroupTemplate = value
            End Set
        End Property
        <Browsable(False), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public Property ColGroup() As ColGroup
            Get
                Me.EnsureChildControls()
                Return _ColGroup
            End Get
            Set(ByVal value As ColGroup)
                _ColGroup = value
            End Set
        End Property
        Protected Overrides Sub CreateChildControls()
            MyBase.CreateChildControls()
            _ColGroup = New ColGroup()
            If Not ColGroupTemplate Is Nothing Then
                ColGroupTemplate.InstantiateIn(_ColGroup)
            End If
            Me.Controls.Add(_ColGroup)
        End Sub
        Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
            EnsureChildControls()
            ' Get the base class's output
            Dim sw As New StringWriter()
            Dim htw As New HtmlTextWriter(sw)
            MyBase.Render(htw)
            Dim output As String = sw.ToString()
            htw.Close()
            sw.Close()
            ' Insert a <COLGROUP> element into the output
            Dim pos As Integer = output.IndexOf("<tr")
            If pos <> -1 AndAlso _ColGroup IsNot Nothing Then
                sw = New StringWriter()
                htw = New HtmlTextWriter(sw)
                _ColGroup.RenderPrivate(htw)
                output = output.Insert(pos, sw.ToString())
                htw.Close()
                sw.Close()
            End If
            ' Output the modified markup
            writer.Write(output)
        End Sub
    End Class
    <ToolboxItem(False)> _
    Public Class ColGroup
        Inherits WebControl
        Implements INamingContainer
        Friend Sub RenderPrivate(ByVal writer As HtmlTextWriter)
            writer.Write("<colgroup>")
            MyBase.RenderContents(writer)
            writer.Write("</colgroup>")
        End Sub
    End Class
    
    End Namespace
