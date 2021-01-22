    Imports System.ComponentModel
    Imports System.Collections
    
    Namespace Controls
    
        Public Class UpdatePanelCss
            Inherits UpdatePanel
            Private _cssClass As String
            Private _tag As HtmlTextWriterTag = HtmlTextWriterTag.Div
    
            <DefaultValue("")> _
            <Description("Applies a CSS style to the panel.")> _
            Public Property CssClass() As String
                Get
                    Return If(_cssClass, [String].Empty)
                End Get
                Set(ByVal value As String)
                    _cssClass = value
                End Set
            End Property
    
            ' Hide the base class's RenderMode property since we don't use it
            <Browsable(False)> _
            <EditorBrowsable(EditorBrowsableState.Never)> _
            <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
            Public Shadows Property RenderMode() As UpdatePanelRenderMode
                Get
                    Return MyBase.RenderMode
                End Get
                Set(ByVal value As UpdatePanelRenderMode)
                    MyBase.RenderMode = value
                End Set
            End Property
    
            <DefaultValue(HtmlTextWriterTag.Div)> _
            <Description("The tag to render for the panel.")> _
            Public Property Tag() As HtmlTextWriterTag
                Get
                    Return _tag
                End Get
                Set(ByVal value As HtmlTextWriterTag)
                    _tag = value
                End Set
            End Property
    
            Protected Overrides Sub RenderChildren(ByVal writer As HtmlTextWriter)
                If IsInPartialRendering Then
                    ' If the UpdatePanel is rendering in "partial" mode that means
                    ' it's the top-level UpdatePanel in this part of the page, so
                    ' it doesn't render its outer tag. We just delegate to the base
                    ' class to do all the work.
                    MyBase.RenderChildren(writer)
                Else
                    ' If we're rendering in normal HTML mode we do all the new custom
                    ' rendering. We then go render our children, which is what the
                    ' normal control's behavior is.
                    writer.AddAttribute(HtmlTextWriterAttribute.Id, ClientID)
                    If CssClass.Length > 0 Then
                        writer.AddAttribute(HtmlTextWriterAttribute.[Class], CssClass)
                    End If
    
                    writer.RenderBeginTag(Tag)
                    For Each child As Control In Controls
                        child.RenderControl(writer)
                    Next
                    writer.RenderEndTag()
                End If
            End Sub
    
        End Class
    
    End Namespace
