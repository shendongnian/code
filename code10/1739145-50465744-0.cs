         private void Form1_KeyPress(object sender, KeyPressEventArgs e)
         {
            barcode = string.Empty;
            try
            {
                barcode += e.KeyChar;
                if (lastTime > new DateTime())
                {
                    if (DateTime.Now.Subtract(lastTime).Milliseconds > 30)
                    {
                        f1 = false;
                    }
                    else
                    {
                        f1 = true;
                    }
                }
                lastTime = DateTime.Now;
                /*
                Test your Barcode, and if it matches your criteria then change your TextBox text
                TextBox1.Text = barcode;
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
         }
