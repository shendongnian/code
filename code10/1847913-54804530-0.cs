    public void Zamknijtab(object sender, RoutedEventArgs e)
        {
            var listaTabow = tabControl.Items;
            var button = sender as RadButton;
            if (button != null)
            {
                button.Click -= Zamknijtab;
                var typ = tabControl.SelectedItem as RadTabItem;
                var tabs = listaTabow.Cast<RadTabItem>();
                if (typ != null)
                {
                    tab = tabs.Reverse().FirstOrDefault(f => f.Name == typ.Name);
                    if (tab != null)
                    {
                        tabControl.Items.Remove(tab);
                        tab = null;
                    }
                }
                GC.Collect();
            }
            else
            {
                var typ = tabControl.SelectedItem as RadTabItem;
                var tabs = listaTabow.Cast<RadTabItem>();
                if (typ != null)
                {
                    tab = tabs.Reverse().FirstOrDefault(f => f.Name == typ.Name);
                    if (tab != null)
                    {
                        tabControl.Items.Remove(tab);
                    }
                }
            }
            App.main.Cursor = Cursors.Arrow;
        }
