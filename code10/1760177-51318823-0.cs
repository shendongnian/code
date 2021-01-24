    bool tempBool_1 = false, tempBool_2 = false;
    if(bool.TryParse(temp[0], out tempBool_1))
    {
          radioButton1.Checked = tempBool_1;
    }
    else
    {
        // handle parsing error.
    }
    if(bool.TryParse(temp[0], out tempBool_2))
    {
          radioButton2.Checked = bool.TryParse(temp[1], out tempBool_2);
    }
    else
    {
        // handle parsing error.
    }
