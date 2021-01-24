    private void Btn_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        string index = btn.Name.Split('_')[1];
        string tbName = "_T_" + index;
        var txtbx= panel3.Controls.Find(tbName, true).First();
        a++;
        txtbx.Text = a.ToString();
    }
