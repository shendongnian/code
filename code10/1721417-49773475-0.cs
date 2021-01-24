    private Stopwatch sw = new Stopwatch();
            private void label1_MouseDown(object sender, MouseEventArgs e)
            {
                sw.Start();
            }
            private void label1_MouseUp(object sender, MouseEventArgs e)
            {
                sw.Stop();
                if (sw.ElapsedMilliseconds > 2500)
                    MessageBox.Show("Mouse held down long enough.");
                else
                    MessageBox.Show("Not long enough.");
            }
