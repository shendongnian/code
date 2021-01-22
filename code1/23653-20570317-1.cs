        private void btnEnter_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Mask = "00/00/0000";
            maskedTextBox1.ValidatingType = typeof(System.DateTime);
            //if (!IsValidDOB(maskedTextBox1.Text)) 
            if (!ValidateBirthday(maskedTextBox1.Text))
            MessageBox.Show(" Not Valid");
            else
                MessageBox.Show("Valid");
        }
        // check date format dd/mm/yyyy. but not if year < 1 or > 2013.
        public static bool IsValidDOB(string dob)
        { 
            DateTime temp;
            if (DateTime.TryParse(dob, out temp))
                return (true);
            else 
                return (false);
        }
        // checks date format dd/mm/yyyy and year > 1900!.
        protected bool ValidateBirthday(String date)
        {
            DateTime Temp;
            if (DateTime.TryParse(date, out Temp) == true &&
                Temp.Year > 1900 &&
               // Temp.Hour == 0 && Temp.Minute == 0 &&
                //Temp.Second == 0 && Temp.Millisecond == 0 &&
                Temp > DateTime.MinValue)
                    return (true);
                else
                    return (false);
        }
