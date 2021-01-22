    public static int Compare(this int a, int b, string compareType)
    {
        switch (CompareType)
        {
            case "Greater Than":
                return fi[i].Length > int.Parse(txtByteValue.Text);
                break;
            case "Less Than":
                return fi[i].Length < int.Parse(txtByteValue.Text);
                break;
            case "Equal To":
                return fi[i].Length == int.Parse(txtByteValue.Text);
                break;
        }
    }
