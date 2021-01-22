    Session["Counter"]=0;
    string[] arr = new string[4] {"A", "B", "C", "D"};
    private void button1_Click(Object sender, EventArgs e)
    {        
        textbox1.Text = arr[int.parse(Session["Counter"])];
        Session["Counter"]=int.parse(Session["Counter"])+1;
        if (int.parse(Session["Counter"]) == arr.Length)
        {
           Session["Counter"]= 0;
        }
    }
