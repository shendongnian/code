    public MainWindow()
    {
        InitializeComponent();
        // Look up label elements by letter
        var labelsLookupByLetter = new Dictionary<char, List<Label>>();
        var buttonsPanel = new UniformGrid
        {
            Columns = 8,
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top
        };
        for (var c = 'a'; c <= 'z'; c++)
        {
            var ch = c;
            var cmd = new Button
            {
                Content = c,
                Width = 24,
                Height = 24
            };
            buttonsPanel.Children.Add(cmd);
            labelsLookupByLetter[ch] = new List<Label>();
            cmd.Click += (sender, e) =>
            {
                if (labelsLookupByLetter.TryGetValue(ch, out var textList))
                {
                    foreach (var el in textList)
                    {
                        el.Content = ch;
                    }
                }
            };
        }
        // Text panel
        var labelsPanel = new WrapPanel();
        var text = "helloworld";
        foreach (var ch in text)
        {
            var textBlock = new Label
            {
                Content = "_"
            };
            labelsLookupByLetter[ch].Add(textBlock);
            labelsPanel.Children.Add(textBlock);
        }
        Content = new StackPanel
        {
            Children = { labelsPanel, buttonsPanel }
        };
    }
