    Imports System.Windows
    Namespace WPF
        Public Class Tooltip
            Public Shared ReadOnly TitleProperty As DependencyProperty = DependencyProperty.Register("Title", GetType(Object), GetType(WPF.Tooltip), New PropertyMetadata(vbNull))
            Public Shared ReadOnly DescProperty As DependencyProperty = DependencyProperty.Register("Desc", GetType(Object), GetType(WPF.Tooltip), New PropertyMetadata(vbNull))
            Public Shared ReadOnly FooterProperty As DependencyProperty = DependencyProperty.Register("Footer", GetType(Object), GetType(WPF.Tooltip), New PropertyMetadata(vbNull))
            Public Shared ReadOnly ImageProperty As DependencyProperty = DependencyProperty.Register("Image", GetType(Object), GetType(WPF.Tooltip), New PropertyMetadata(vbNull))
    
            Public Property Title As Object
                Get
                    Return GetValue(TitleProperty)
                End Get
                Set(value As Object)
                    SetValue(TitleProperty, value)
                End Set
            End Property
            Public Property Desc As Object
                Get
                    Return GetValue(DescProperty)
                End Get
                Set(value As Object)
                    SetValue(DescProperty, value)
                End Set
            End Property
            Public Property Footer As Object
                Get
                    Return GetValue(FooterProperty)
                End Get
                Set(value As Object)
                    SetValue(FooterProperty, value)
                End Set
            End Property
            Public Property Image As Object
                Get
                    Return GetValue(ImageProperty)
                End Get
                Set(value As Object)
                    SetValue(ImageProperty, value)
                End Set
            End Property
    
            Private Sub Hyperlink_RequestNavigate(sender As Object, e As Navigation.RequestNavigateEventArgs)
                System.Diagnostics.Process.Start(e.Uri.ToString())
            End Sub
        End Class
    End Namespace
