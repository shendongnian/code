    /// <summary>
    /// used for editor definition on those properties that should be able 
    /// to select a resource
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor" />
    class ResourceDropDownListPropertyEditor : UITypeEditor
    {
        IWindowsFormsEditorService _service;
             
        /// <summary>
        /// Gets the editing style of the <see cref="EditValue"/> method.
        /// </summary>
        /// <param name="context">An ITypeDescriptorContext that can be used to gain additional context information.</param>
        /// <returns>Returns the DropDown style, since this editor uses a drop down list.</returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            // We're using a drop down style UITypeEditor.
            return UITypeEditorEditStyle.DropDown;
        }
    
        /// <summary>
        /// Displays a list of available values for the specified component than sets the value.
        /// </summary>
        /// <param name="context">An ITypeDescriptorContext that can be used to gain additional context information.</param>
        /// <param name="provider">A service provider object through which editing services may be obtained.</param>
        /// <param name="value">An instance of the value being edited.</param>
        /// <returns>The new value of the object. If the value of the object hasn't changed, this method should return the same object it was passed.</returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                // This service is in charge of popping our ListBox.
                _service = ((IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService)));
    
                if (_service != null)
                {
    
    
                    var items = typeof(Properties.Resources).GetProperties()
                                .Where(p => p.PropertyType == typeof(string))
                                .Select(s => s.Name)
                                .OrderBy(o => o);
    
                    var list = new ListBox();
                    list.Click += ListBox_Click;
    
                    foreach (string item in items)
                    {
                        list.Items.Add(item);
                    }
                    if (value != null)
                    {
                        list.SelectedValue = value;
                    }
    
                    // Drop the list control.
                    _service.DropDownControl(list);
    
                    if (list.SelectedItem != null && list.SelectedIndices.Count == 1)
                    {
                        list.SelectedItem = list.SelectedItem.ToString();
                        value = list.SelectedItem.ToString();
                    }
    
                    list.Click -= ListBox_Click;
                }
            }
    
            return value;
        }
    
        private void ListBox_Click(object sender, System.EventArgs e)
        {
            if (_service != null)
                _service.CloseDropDown();
    
                
        }
    }
