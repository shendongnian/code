     protected void LinqDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            if(Request.QueryString["id"] != null)
            {
                   var myImage = from img in imageSource
                                 where img.ID == Request.QueryString["id"]
                                 select img;
                   e.Result = myImage;
            }
            else
            {
                   e.Result = imageSource;
            }
    
           
        }
