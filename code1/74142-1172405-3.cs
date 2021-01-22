    public void myrepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      myDataObject = e.Item.DataItem;
      Label data1 = e.Item.FindControl("data1");
      Label data2 = e.Item.FindControl("data2");
    	
      data1.Text = myDataObject.data1;
      data2.Text = myDataObject.data2;
    }
