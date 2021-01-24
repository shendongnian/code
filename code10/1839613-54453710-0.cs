        private void timer1_Tick(object sender, EventArgs e)
        {
            statmessage();
            int i = listBox1.SelectedItems.Count + 1;
            do
            {
                var exp = (EItem)listBox1.Items[i];
                var timeVisible = DateTime.Now - exp.Added;
                if (timeVisible.TotalSeconds > 5)
                    if (counter == 100)
                    {
                        SendMessage();
                        counter = counter - 1;
                        ++i;
                    }
                    else if (counter <= 0)
                    {
                      statmessage();
                    }
            } while (i < -1);
            }
