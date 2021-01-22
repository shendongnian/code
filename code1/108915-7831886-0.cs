        string value = txtDetails.Text;
        char[] delimiter = new char[] { ';','[' };
        string[] parts = value.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < parts.Length; i++)
        {
            txtFName.Text = parts[0].ToString();
            txtLName.Text = parts[1].ToString();
            txtAge.Text = parts[2].ToString();
            txtDob.Text = parts[3].ToString();
        }
    }
