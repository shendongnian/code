     int n = check_textbox.Text.Length;
            int check = Convert.ToInt32(check_textbox.Text);
            int m = 0;
            double latest=0;
            for (int i = n - 1; i>-1; i--)
            {
                    double exp = Math.Pow(10, i);
                    double rem = check / exp;
                    string rem_s = rem.ToString().Substring(0, 1);
                    int ret_rem = Convert.ToInt32(rem_s);
                    double exp2 = Math.Pow(10, m);
                    double new_num = ret_rem * exp2;
                    m=m+1;
                    latest = latest + new_num;
                    double my_value = ret_rem * exp;
                    int myvalue_int = Convert.ToInt32(my_value);
                    check = check - myvalue_int;
            }
            int latest_int=Convert.ToInt32(latest);
            if (latest_int == Convert.ToInt32(check_textbox.Text))
            {
                MessageBox.Show("The number is a Palindrome      number","SUCCESS",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The number is not a Palindrome number","FAILED",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
