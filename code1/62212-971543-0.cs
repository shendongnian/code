    CheckBox[] myCB = new CheckBox[100];
    for (int i = 0; i < myCB.Length; i++)
    {
        myCB[i] = new CheckBox();
        myCB[i].Text = "Clicky!";
        myCB[i].Click += new System.EventHandler(dynamicbutton_Click);
        myCB[i].Tag = i;
        tableLayoutPanel1.Controls.Add(myCB[i]);
    }
