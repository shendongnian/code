    private void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                if (txt.Text.Length == 1 && e.KeyValue == (int)txt.Text[0]) //--------->> error
                {
                    MessageBox.Show("success");
                }
            }
