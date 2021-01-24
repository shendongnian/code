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
            //if you want user press again in limited timespan, use a timer to start another counting here, once timeout, reset count to 0
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
