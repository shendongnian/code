    Imports System.ComponentModel
    Imports System.Collections 
    Imports System.Web.UI        
    
    Namespace Controls
    
    	Public Class UpdatePanelCss
    	    Inherits UpdatePanel
    	    Private _cssClass As String
    	    Private _tag As HtmlTextWriterTag = HtmlTextWriterTag.Div
    	    Public HtmlAttributes As New HtmlAttributes
    	
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
    	            If HtmlAttributes.Count > 0 Then
    	                For Each ha As HtmlAttribute In HtmlAttributes
    	                    writer.AddAttribute(ha.AttrName, ha.AttrVal)
    	                Next
    	            End If
    	            writer.RenderBeginTag(Tag)
    	            For Each child As Control In Controls
    	                child.RenderControl(writer)
    	            Next
    	            writer.RenderEndTag()
    	        End If
    	    End Sub
    	
    	End Class
    
    	Public Class HtmlAttribute
    	    Private PAttrName As String
    	    Private PAttrVal As String
    	
    	    Public Sub New(AttrName As String, AttrVal As String)
    	        PAttrName = AttrName
    	        PAttrVal = AttrVal
    	    End Sub
    	
    	    Public Property AttrName() As String
    	        Get
    	            Return PAttrName
    	        End Get
    	        Set(value As String)
    	            PAttrName = value
    	        End Set
    	    End Property
    	
    	    Public Property AttrVal() As String
    	        Get
    	            Return PAttrVal
    	        End Get
    	        Set(value As String)
    	            PAttrVal = value
    	        End Set
    	    End Property
    	
    	End Class
    	
    	
    	Public Class HtmlAttributes
    	    Inherits CollectionBase
    	
    	    Public ReadOnly Property Count() As Integer
    	        Get
    	            Return List.Count
    	        End Get
    	    End Property
    	
    	    Default Public Property Item(ByVal index As Integer) As HtmlAttribute
    	        Get
    	            Return CType(List.Item(index), HtmlAttribute)
    	        End Get
    	        Set(ByVal Value As HtmlAttribute)
    	            List.Item(index) = Value
    	        End Set
    	    End Property
    	
    	    Public Function Add(ByVal item As HtmlAttribute) As Integer
    	        Return List.Add(item)
    	    End Function
    	
    	    Public Sub Remove(ByVal index As Integer)
    	        If index < List.Count AndAlso List.Item(index) IsNot Nothing Then
    	            List.RemoveAt(index)
    	        Else
    	            Throw New Exception(String.Concat("Index(", index.ToString, ") is not valid. List only has ", List.Count.ToString, " items."))
    	        End If
    	    End Sub
    	
    	    Public Sub Remove(ByRef hAttribute As HtmlAttribute)
    	        If List.Count > 0 AndAlso List.IndexOf(hAttribute) >= 0 Then
    	            List.Remove(hAttribute)
    	        Else
    	            Throw New Exception("Object does not exist in collection.")
    	        End If
    	    End Sub
    	
    	End Class
    
    
    End Namespace
