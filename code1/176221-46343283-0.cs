            private void button2_Click(object sender, EventArgs e)
        {
            string HKCUval = textBox1.Text;
            RegistryKey HKCU = Registry.CurrentUser;
            //Checks if HKCUval exist.
            try {
                HKCU.DeleteSubKey(HKCUval); //if exist.
            }
            catch (Exception)
            {
                MessageBox.Show(HKCUval + " Does not exist"); //if does not exist.
            }
            }
