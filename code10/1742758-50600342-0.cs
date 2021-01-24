    public static void FillTree()
    {
        BIMExplorerUserControl.Instance.BimTreeView.ItemTemplate = GetTemplate();
       
        BIMExplorerUserControl.Instance.BimTreeView.ItemsSource = ViewModel.Instance.DefaultExplorerView;
    }
    public static HierarchicalDataTemplate GetTemplate()
    {
        //create the data template
        HierarchicalDataTemplate dataTemplate = new HierarchicalDataTemplate();
        //create stack pane;
        FrameworkElementFactory stackPanel = new FrameworkElementFactory(typeof(StackPanel));
        stackPanel.Name = "parentStackpanel";
        stackPanel.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
        ////// Create check box
        FrameworkElementFactory checkBox = new FrameworkElementFactory(typeof(CheckBox));
        checkBox.Name = "chk";
        checkBox.SetValue(CheckBox.NameProperty, "chk");
        checkBox.SetValue(CheckBox.TagProperty, new Binding());
        checkBox.SetValue(CheckBox.MarginProperty, new Thickness(2));
        checkBox.SetValue(CheckBox.TagProperty, new Binding() { Path = new PropertyPath("Name") });
        stackPanel.AppendChild(checkBox);
        // create text
        FrameworkElementFactory label = new FrameworkElementFactory(typeof(TextBlock));
        label.SetBinding(TextBlock.TextProperty, new Binding() { Path = new PropertyPath("Name") });
        label.SetValue(TextBlock.MarginProperty, new Thickness(2));
        label.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
        label.SetValue(TextBlock.ToolTipProperty, new Binding());
        stackPanel.AppendChild(label);
        dataTemplate.ItemsSource = new Binding("Elements");
        //set the visual tree of the data template
        dataTemplate.VisualTree = stackPanel;
        return dataTemplate;
    }
