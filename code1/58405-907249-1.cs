    protected virtual void AddButtonPressed(object sender, System.EventArgs e) {
       Console.WriteLine("Button pressed");
       Gtk.Button button = sender as Gtk.Button;
       Console.WriteLine("Index: {0}", button.Tag);
    }
