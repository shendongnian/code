    private void Button_Click(object sender, EventArgs e)
    {
       Button b = (Button) sender;
       XmlElement elm = (XmlElement)b.DataContext;
       int row = Convert.ToInt32(elm.GetAttribute("Row"));
       int column = Convert.ToInt32(elm.GetAttribute("Column"));
       // now do whatever you need to do with the row and column
    }
