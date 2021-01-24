    DataGridRow row = (DataGridRow)dtgFeatures.ItemContainerGenerator.ContainerFromIndex(0);
    if (row != null)
    {
        var content = dtgFeatures.Columns[0].GetCellContent(row);
        if (content != null)
        {
            TextBlock textBlock = (TextBlock)content;
            if (textBlock.Text.ToUpper().Trim().Contains(tbxSrc.Text.ToUpper().Trim()))
            {
                string str = textBlock.Text.Replace(tbxSrc.Text, tbxDest.Text);
                textBlock.Text = str;
                BindingExpression be = textBlock.GetBindingExpression(TextBlock.TextProperty);
                if (be != null && be.ParentBinding != null && be.ParentBinding.Path != null && !string.IsNullOrEmpty(be.ParentBinding.Path.Path))
                {
                    object cfgPartPrograms = textBlock.DataContext;
                    if (cfgPartPrograms != null)
                    {
                        System.Reflection.PropertyInfo pi = typeof(CfgPartPrograms).GetProperty(be.ParentBinding.Path.Path);
                        if (pi != null)
                            pi.SetValue(cfgPartPrograms, str);
                    }
                }
            }
        }
    }
