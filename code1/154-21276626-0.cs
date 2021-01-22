    private bool ValidateDate(string dob)
        {
            DateTime dobdate = DateTime.Parse(dob);
            DateTime nowdate = DateTime.Now;
            TimeSpan ts = nowdate - dobdate;
            int Years = ts.Days / 365;
            if (Years < 18)
            {
                message = "Date of Birth must not be less then 18";
                return false;
            }
            else if (Years > 65)
            {
                message = "Date of Birth must not be greater then 65";
                return false;
            }
            dobvalue = dob;
            return true;
        }
      //Below here you call that function and pass out datetime value (MM/DD/YYYY) you can format by any way you like
      //Function Call
      if (ValidateDate("03/10/1982") == false)
         {
            lbldatemessaeg.Visible = true;
            lbldatemessaeg.Text = message; //you can replace anything a messagebox,or any container to display
            return;
         }
