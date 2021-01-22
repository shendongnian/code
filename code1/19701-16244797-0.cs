            public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var editorService = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
            if (editorService != null)
            {
                var selectionControl = new TextArrayPropertyForm((string[])value, "Edit the lines of text", "Label Editor");
                editorService.ShowDialog(selectionControl);
                if (selectionControl.DialogResult == DialogResult.OK)
                    value = selectionControl.Value;
            }
            return value ?? new string[] {};
        }
