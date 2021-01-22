    CheckBox[] myCB = new CheckBox[100];
    for (int i = 0; i < myCB.Length; i++)
    {
        int index = i; // This is very important, as otherwise i will
                      // be captured for all of them
        myCB[i] = new CheckBox();
        myCB[i].Text = "Clicky!";
        myCB[i].Click += (s, e) => label1.Text = index.ToString();
        tableLayoutPanel1.Controls.Add(myCB[i]);
    }
