     public class CustomMessageBox
        {
            public CustomMessageBox()
            {
                Window w = new Window();
                DockPanel panel = new DockPanel();
                TextBlock tx = new TextBlock();
                Paragraph parx = new Paragraph();
                Run run1 = new Run("Text preceeding the hyperlink.");
                Run run2 = new Run("Text following the hyperlink.");
                Run run3 = new Run("Link Text.");
                Hyperlink hyperl = new Hyperlink(run3);
                hyperl.NavigateUri = new Uri("http://search.msn.com");
                tx.Inlines.Add(hyperl);
                panel.Children.Add(tx);
                w.Content = panel;
                w.Show();
            }
        }
