    string str1 = tbline.Text;
    string str2 = tbsubstr.Text;
    if (tbline.Text == "" || tbsubstr.Text == "")
    {
        MessageBox.Show("Please enter a line and also enter sunstring text in textboo");
    }
    else
    {
        **string delresult = str1.Replace(str2, "");**
        tbresult.Text = delresult;
    }**
