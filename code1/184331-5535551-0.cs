    public class CustomComboBox : ComboBox
    {
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Grid grid = WpfHelper.FindAllChildrenByName<Grid>(this, "MainGrid").SingleOrDefault() as Grid;
            if (grid != null)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                Button button = new Button();
                button.Content = "test";
                button.SetValue(Grid.ColumnProperty, 2);
                grid.Children.Add(button);
            }
        } 
    }
