        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            timer1.Stop();
            if (!e.KeyCode.HasFlag(Keys.Space))
            {
                counting = 0;
                return;
            }
            //start counting
            timer1.Start();
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
        //timer1.Interval = 100; //100ms timeout. user has to press space again within 100ms
        private void timer1_Tick(object sender, EventArgs e)
        {
            counting = 0;
        }
