        private void ProcessMenu(RootMenu rm)
        {
            foreach (var lnk in rm.Links)
            {
                var tsmi = new UrlToolStripMenuItem(lnk.Name, null, new EventHandler(Navigate))
                {
                    Url = lnk.Url,
                };
                ContextMenu.Items.Add(tsmi);
            }
        }
        private void Navigate(object sender, EventArgs e)
        {
            var tsmi = (UrlToolStripMenuItem)sender;
            System.Diagnostics.Process.Start(tsmi.Url);
        }
        public class UrlToolStripMenuItem : ToolStripMenuItem
        {
            public UrlToolStripMenuItem(string text, Image image, EventHandler onClick) : base(text, image, onClick)
            {
            }
            public string Url { get; set; }
        }
