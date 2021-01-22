    protected void Page_Init(object sender, EventArgs e)
    {
        foreach(object link in myArrayList)
        {
            string url = link as string;
            if(url != null)
            {
                HyperLink l = new HyperLink();
                l.NavigateUrl = l.Text = url;
                myPlaceHolder.Controls.Add(l);
            }
        }
    }
