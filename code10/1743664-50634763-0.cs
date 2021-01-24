    public static readonly DependencyProperty EditorFormulaProperty =
            DependencyProperty.Register("EditorFormula", typeof(ICommand), typeof(FormIndexControl), new PropertyMetadata(EditorFormulaPropertyCallback));
    
    public static void EditorFormulaPropertyCallback(DependencyObject depObj,
                DependencyPropertyChangedEventArgs args)
            {
                if (depObj is StackPanel)
                {
                    (depObj as StackPanel).MouseLeftButtonDown -= OnMouseLeftButtonDown;
                    (depObj as DockingManager).MouseLeftButtonDown += OnMouseLeftButtonDown;
                }
            }
    
    private static void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e e)
            {
                ICommand cmd = GetEditorFormulaPropertyCommand(sender as StackPanel);
    
                if (cmd != null)
                {
                    if (sender as UIElement == null)
                    {
                        return;
                    }
    
                    cmd.Execute(e);
                }
            }
    
    public static ICommand GetEditorFormulaPropertyCommand(UIElement element)
            {
                return element.GetValue(EditorFormulaProperty) as ICommand;
            }
