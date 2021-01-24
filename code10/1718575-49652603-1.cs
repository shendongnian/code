        public MainWindow()
        {
            InitializeComponent();
            Button b = new Button();
            b.Content = "custom Button 1 ";
            buttons.Add(b);
            b = new Button();
            b.Content = "custom button 2 ";
            buttons.Add(b);
            b = new Button();
            b.Content = "custom button 3 ";
            buttons.Add(b);
            Row[] rows = new Row[(int)Math.Ceiling(buttons.Count / 2.0)];
            int buttonIndex = 0;
            for (int i = 0; i < rows.Length; ++i)
            {
                rows[i] = new Row();
                rows[i].Col1 = buttons[buttonIndex++];
                if (buttons.Count > buttonIndex)
                    rows[i].Col2 = buttons[buttonIndex++];
            }
            listBox.ItemsSource = rows;
        }
