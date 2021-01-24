    double x;
    double y;
    string strx = TextBoxX.Text;
    string stry = TextBoxY.Text;
    List<string>() invalids = new List<string>();
    
    if (!double.tryParse(strx, out double a))
        {invalids.Add("boxX");}
    
    if (!double.tryParse(stry, out double b))
        {invalids.Add("boxY")}
    if invalids.Length != 0
        {MessageBox.Show("Incorrect inputs in " + String.Join(", ", invalids.ToArray());}
    
    x = a;
    y = b; 
