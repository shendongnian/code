    protected override void OnInit(EventArgs e)
            {
                base.OnInit(e);
                MyUserControl.Button_Click+= MyUserControl_Button_Click;
            }
    
     void MyUserControl_Button_Click(object sender,EventArgs e)
            { }
