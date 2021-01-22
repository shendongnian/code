    protected void RowCommand(object sender, GridViewCommandEventArgs e)
    {
    	if (e.CommandName == "DeleteThisOne")
    	{
    		int iTheIndexNow;
    		if (int.TryParse(e.CommandArgument.ToString(), out iTheIndexNow))
    		{
    			// Maybe this not needed because of your redirect.
    			SellersGridView.SelectedIndex = iTheIndexNow;
                        bool fAllIsOk = true;
    			try
    			{
    				string seller = ((Label)SellersGridView.Rows[iTheIndexNow].Cells[0].FindControl("TextBoxSeller")).Text;
    				BookStore b = new BookStore();
    				b.LoadFromXML(Server.MapPath("list.xml"));
    				string ISBN = Request.QueryString["ISBN"].ToString();
    				int ID = b.BooksList.FindIndex(x => x.ISBN == ISBN);
    				Book myBook = b.BooksList[ID];
    				myBook.RemoveSeller(seller);
    			}
    			catch (Exception x)
    			{
                                fAllIsOk = false;
    				...show the error....
    			}
                        if(fAllIsOk)
  			  Response.Redirect("editbook.aspx?ISBN=" + ISBN);
    		}
    	}
    }
