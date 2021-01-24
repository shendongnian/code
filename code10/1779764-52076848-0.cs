    protected void GenerateOTP(object sender, EventArgs e)
    {
        string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
        string numbers = "1234567890";
 
        string characters = numbers;
        if (rbType.SelectedItem.Value == "1")
        {
             characters += alphabets + small_alphabets + numbers;
        }
        int length = int.Parse(ddlLength.SelectedItem.Value);
        string otp = string.Empty;
        for (int i = 0; i < length; i++)
        {
            string character = string.Empty;
            do
            {
                int index = new Random().Next(0, characters.Length);
                character = characters.ToCharArray()[index].ToString();
            } while (otp.IndexOf(character) != -1);
            otp += character;
        }
        lblOTP.Text = otp;
     }
