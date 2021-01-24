    using System.ComponentModel;
    using System.Windows.Interactivity;
    class ExtendendHeadersBehavior : Behavior<DataGrid>
    {
        protected override void OnAttached()
        {
            AssociatedObject.AutoGeneratingColumn += AssociatedObject_AutoGeneratingColumn;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.AutoGeneratingColumn -= AssociatedObject_AutoGeneratingColumn;
        }
        private void AssociatedObject_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyDescriptor is PropertyDescriptor desc)
            {
                string header = desc.Attributes.OfType<DescriptionAttribute>()
                    .FirstOrDefault()?.Description;
                if (!string.IsNullOrEmpty(header))
                {
                    e.Column.Header = header;
                }
            }      
        }
    }
