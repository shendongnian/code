    private void SomeCustomEvent(object sender, EventArgs e)
    {
        if (radBtnOne.Checked) //If checked == true
        {
            M_TitleTextBox.Text = "From radio button one";                        
        }
        else if(radBtnTwo.Checked)
        {
            M_TitleTextBox.Text = "From radio button two";
        }
    }
