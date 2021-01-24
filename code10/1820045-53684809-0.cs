    protected void Button1_Click(object sender, EventArgs e)
    {
        Person p = new Person(Convert.ToInt32(DropDownList1.SelectedValue), TextBox1.Text, Calendar1.SelectedDate, Convert.ToInt32(TextBox2.Text), DropDownList2.Text);
        Label2.Text = p.PresentPerson();
    }
