        int theCount = 0;
        int[] numbers = new int[20];
        private void btnEnter_Click(object sender, EventArgs e)
        {
            int numToAdd;
            if (int.TryParse(txtNumToAdd.Text, out numToAdd))
            {
                if (theCount < 20)
                {
                    theCount++;
                    numbers[theCount -1] = numToAdd;
                    lblNumCount.Text = string.Format("{0} / 20", theCount.ToString());
                }
                else
                {
                    MessageBox.Show("You cannot exceed 20 numbers!");
                }
            }
        }
