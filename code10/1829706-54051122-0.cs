    public void UserControl_ButtonClick(object sender, EventArgs e, int number)
    {
        UserControlClick(number);
    }
       
    public void UserControlClick(int number)
    {
        UserControl con=null ;
        if (number == 0)
             con = UserMainPanel_Saved.Instanse;
        else
        {               
                if (UserPassword.Password)
                {
                    if (number == 1)
                        con = UserMainDaybook.Instanse;
                }
                else
                {
                    con = UserPassword.Instanse;
                }
        }
        if (!MainPanel.Controls.Contains(con))
        { 
           MainPanel.Controls.Add( con);
           con.Dock = DockStyle.Fill;
           con.BringToFront();
        }          
        else
        {
           con.BringToFront();
        }
    }```
