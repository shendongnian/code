       public class DataGridReadOnlyObjectDisplayColumn : DataGridBoundColumn {
    
          public DataGridReadOnlyObjectDisplayColumn() {
             //set as read only,
             this.IsReadOnly = true;
          }
    
    
          /// <summary>
          /// Gets and Sets the Cell Template for this column
          /// </summary>
          public DataTemplate CellTemplate {
             get { return (DataTemplate)GetValue(CellTemplateProperty); }
             set { SetValue(CellTemplateProperty, value); }
          }
    
          // Using a DependencyProperty as the backing store for CellTemplate.  This enables animation, styling, binding, etc...
          public static readonly DependencyProperty CellTemplateProperty =
              DependencyProperty.Register("CellTemplate", typeof(DataTemplate), typeof(DataGridReadOnlyObjectDisplayColumn), new UIPropertyMetadata(null));
    
    
    
          protected override System.Windows.FrameworkElement GenerateElement(DataGridCell cell, object dataItem) {
             //create the simple field text block
             ContentControl contentControl = new ContentControl();
    
             contentControl.Focusable = false;
    
             //if we have a cell template use it
             if (this.CellTemplate != null) {
                contentControl.SetValue(ContentControl.ContentTemplateProperty, this.CellTemplate);
             }
    
             //set the binding
             ApplyBinding(contentControl, ContentPresenter.ContentProperty);
    
             //return the text block
             return contentControl;
          }
    
          /// <summary>
          ///     Assigns the Binding to the desired property on the target object.
          /// </summary>
          internal void ApplyBinding(DependencyObject target, DependencyProperty property) {
             BindingBase binding = Binding;
    
             if (binding != null) {
                BindingOperations.SetBinding(target, property, binding);
             }
             else {
                BindingOperations.ClearBinding(target, property);
             }
          }
    
          protected override System.Windows.FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem) {
             //item never goes into edit mode it is a read only column
             return GenerateElement(cell, dataItem);
          }
       }
