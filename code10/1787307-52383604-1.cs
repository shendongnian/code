    /// <summary>
            /// when the selection is changed to an item it will update the labels contents through a method in the class activityChecker.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void cmbNomiMacchine_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                updateLabelsContent();
                Thread t = new Thread(updateLabelsContentThread);
                t.Start();
    
            }
