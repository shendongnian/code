    protected void Button1_Click(object sender, EventArgs e)
    {
        if (txtActivity.Text == "")
        {
            lbSave.ForeColor = Color.Red;
            lbSave.Font.Bold = true;
            lbSave.Text = "Please enter activity!";
        }
        else
        {
            
           bind();
        }
        }
    }
}
