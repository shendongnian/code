    public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
                StackPanel sp = new StackPanel();
    
                for (int i = 0; i < 3; i++)
                {
                    
                    TextBox tb = new TextBox();
                    tb.Width = 200;
                    tb.Margin = new Thickness { Bottom = 3 };
                    sp.Children.Add(tb);
                }
                FormArea.Content = sp;
                sp.Children[1].Focus();
            }
        }
