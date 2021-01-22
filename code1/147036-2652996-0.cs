        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //Remove any KeyPress events already attached
            e.Control.KeyPress -= new KeyPressEventHandler(FirstEditingControl_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(SecondEditingControl_KeyPress);
            //Choose event to wire based on control type
            if (e.Control is NumericTextBox)
            {
                e.Control.KeyPress += new KeyPressEventHandler(FirstEditingControl_KeyPress);
            } else if (e.Control is CurrencyTextBox)
            {
                e.Control.KeyPress += new KeyPressEventHandler(SecondEditingControl_KeyPress);
            }
        }
