        private int counting = 0, limit = 10;
        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.HasFlag(Keys.Space)) //check if your expected key is pressed
            {
                counting = 0;
                return;
            }
            //start counting
            counting++;
            if (counting > limit)
            {
                e.Handled = true;
                //do you business work, like: Send something somewhere
            }
            else
            {
                //do something else, like: show the number 'counting' in GUI
            }
        }
