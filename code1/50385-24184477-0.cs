    Public Class WatermarkExtender
        Inherits DependencyObject
    
        Public Shared ReadOnly WatermarkProperty As DependencyProperty =
            DependencyProperty.RegisterAttached(
                "Watermark",
                GetType(Object),
                GetType(WatermarkExtender),
                New UIPropertyMetadata(Nothing))
    
        Public Shared ReadOnly WatermarkTemplateProperty As DependencyProperty =
            DependencyProperty.RegisterAttached(
                "WatermarkTemplate",
                GetType(DataTemplate),
                GetType(WatermarkExtender),
                New UIPropertyMetadata(Nothing))
    
        Public Shared Sub SetWatermark(ByVal element As UIElement, ByVal value As Object)
            element.SetValue(WatermarkProperty, value)
        End Sub
    
        Public Shared Function GetWatermark(ByVal element As UIElement) As Object
            Return element.GetValue(WatermarkProperty)
        End Function
    
        Public Shared Sub SetWatermarkTemplate(ByVal element As UIElement, ByVal value As Object)
            element.SetValue(WatermarkTemplateProperty, value)
        End Sub
    
        Public Shared Function GetWatermarkTemplate(ByVal element As UIElement) As Object
            Return element.GetValue(WatermarkTemplateProperty)
        End Function
    End Class
