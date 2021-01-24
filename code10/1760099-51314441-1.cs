    // check for the length first
    if (txtId.Text.Length < 13)
    {
        LblDisp.Text = "Invalid Length";
        return;
    }
    // use substring later. You dont want to substring on a short string.
    // If you try you can get ArgumentOutOfRangeException.
    string id = txtId.Text;
    string year = id.Substring(0, 2); // substring returns a string
    string month = id.Substring(2, 2);
    string day = id.Substring(4, 2);
    string gender = id.Substring(6, 1);
    // by the way, you should check if all this chars are numbers. You can use int.TryParse for this.
    int yy = int.TryParse(year);
    int mm = int.Parse(month);
    int dd = int.Parse(day);
    int xx = int.Parse(gender);
    if (!(yy >= 40 && yy <= 99) || (yy >=0 && yy <= 18))
    {
        LblDisp.Text = "Invalid Year";
    }
