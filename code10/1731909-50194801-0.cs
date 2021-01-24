    public void someBtnFunct(object sender) 
    {
        myButton btn = sender as myButton;
        List<string> hostList = IList();
        MessageBox.Show(hostList[btn.GetNum1()]); //messagebox selected button playlist title 
        //MessageBox.Show(btn.Num1 + ", " + iList[1] + "Button Clicked");
     }
