    private void Aggiungi_Click(object sender, RoutedEventArgs e)
            {
                TextBox txt = FindVisualChildByName<TextBox>(dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex) as DataGridRow, "txtQTA", dataGrid.SelectedIndex);
                txt.Text = "Writing";
            }
            public T FindVisualChildByName<T>(DependencyObject parent, string name, int nRiga) where T : DependencyObject
            {
    
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
    
    
    
                {
    
                    var child = VisualTreeHelper.GetChild(parent, i);
    
                    string controlName = child.GetValue(Control.NameProperty) as string;
    
                    if (controlName == name)
    
                    {
    
                        return child as T;
    
                    }
    
                    else
    
                    {
    
                        T result = FindVisualChildByName<T>(child, name, nRiga);
    
                        if (result != null)
    
                            return result;
    
                    }
    
                }
    
                return null;
    
            }
