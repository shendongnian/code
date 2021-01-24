            void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
            {
                if ( e.Control is ComboBox comboEdited ) {
                    comboEdited.SelectedIndexChanged +=
                        (sender, evt) => this.OnComboSelectedIndexChanged( sender );
                }
    
                return;
            }
    
            void OnComboSelectedIndexChanged(object sender)
            {
                int selectedIndex = ((ComboBox) sender).SelectedIndex;
    
                selectedIndex = System.Math.Max( 0, selectedIndex );
                string selectedValue = MainFormView.ListBoxItems[ selectedIndex ];
    
                this.Form.EdSelected.Text = selectedValue;
    }
