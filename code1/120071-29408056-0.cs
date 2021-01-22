            try
            {
                checked
                {
                    int y = 1000000000;
                    short x = (short)y;
                }
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Overflow");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
