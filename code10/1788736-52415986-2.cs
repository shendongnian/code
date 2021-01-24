    protected void Call_Desc(object sender, EventArgs e)
        {
            switch ((sender as TextBox).ID)
            {
                case "ItmCde":
                    //actions
                    Desc.Text = ItmCde.Text;
                    break;
                case "ItmCde2":
                    Desc2.Text = ItmCde2.Text;
                    //actions
                    break;
                default:
                    break;
            }
        }
    
