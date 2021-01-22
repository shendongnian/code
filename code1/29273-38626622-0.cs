    Here is a simple solution that works for me.
    public static bool numResult;
        public static bool checkTextisNumber(string numberVal)
        {
            try
            {
                if (numberVal.Equals("."))
                {
                    numResult = true;
                }
                else if (numberVal.Equals(""))
                {
                    numResult = true;
                }
                else
                {
                    decimal number3 = 0;
                    bool canConvert = decimal.TryParse(numberVal, out number3);
                    if (canConvert == true)
                    {
                        numResult = true;
                    }
                    else
                        numResult = false;
                }
            }
            catch (System.Exception ex)
            {
                numResult = false;
            }
            return numResult;
        }
        string correctNum;
        private void tBox_NumTester_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if(checkTextisNumber(tBox_NumTester.Text))
            {
                correctNum = tBox_NumTester.Text;
            }
            else
            {
                tBox_NumTester.Text = correctNum;
            }
        }
