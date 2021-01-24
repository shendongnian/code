            if (!(txtId.Text.Length==13))
            {
                LblDisp.Text = "Invalid Length";
            }
            else
            {
                string id = txtId.Text; // you do not need to even do SubString now as you know it is a length of 13
                string year = id.Substring(0, 2).ToString();
                string month = id.Substring(2, 2).ToString();
                string day = id.Substring(4, 2).ToString();
                string gender = id.Substring(6, 1).ToString();
    
                int yy = int.Parse(year);
                int mm = int.Parse(month);
                int dd = int.Parse(day);
                int xx = int.Parse(gender);
    
                if (!(yy >= 40 && yy <= 99) || (yy >=0 && yy <= 18))
                {
                    LblDisp.Text = "Invalid Year";
                } 
