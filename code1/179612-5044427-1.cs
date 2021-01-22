    void Grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        ComboBox combo = e.Control as ComboBox;
        if (combo != null)
        {
            // the event to handle combo changes
            EventHandler comboDelegate = new EventHandler(
                (cbSender, args) =>
                {
                    DoSomeStuff();
                });
            // register the event with the editing control
            combo.SelectedValueChanged += comboDelegate;
            // since we don't want to add this event multiple times, when the 
            // editing control is hidden, we must remove the handler we added.
            EventHandler visibilityDelegate = null;
            visibilityDelegate = new EventHandler(
                (visSender, args) =>
                {
                    // remove the handlers when the editing control is
                    // no longer visible.
                    if ((visSender as Control).Visible == false)
                    {
                        combo.SelectedValueChanged -= comboDelegate;
                        visSender.VisibleChanged -= visibilityDelegate;
                    }
                });
            (sender as DataGridView).EditingControl.VisibleChanged += 
               visibilityDelegate;
            
        }
    }
