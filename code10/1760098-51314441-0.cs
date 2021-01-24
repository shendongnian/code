    // check for the length first
    if (txtId.Text.Length < 13)
    {
        LblDisp.Text = "Invalid Length";
        return;
    }
    // use substring later. You dont want to substring on a short string.
    // If you try you can get ArgumentOutOfRangeException.
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
