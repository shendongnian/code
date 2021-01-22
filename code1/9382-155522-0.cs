        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var p = new Class1();
                p.Test3();
            }
            catch (COMException ex)
            {
                int errorNumber = (ex.ErrorCode - (-2147221504));
                MessageBox.Show(errorNumber.ToString() + ": " + ex.Message);
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }
