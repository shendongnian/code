    for (int nCount = 0; nCount < 2; nCount++)
    {
       CheckUserControl uc = new CheckUserControl();
       //If required Assign Value to the control
       uc.strValue = "Item " + nCount;
       uc.strTag = nCount.ToString();
       //You can pass the Column and Row value dynamically
       tableLayoutPanel1.Controls.Add(uc, 1, 1);
    }
