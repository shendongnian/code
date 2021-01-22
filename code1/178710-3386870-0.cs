    protected void Page_Load(object sender, EventArgs e)
    {
         int id;
         if (Int32.TryParse(Request.QueryString["file"], out id))
         {
              Count(id); // increment the counter
              GetFile(id); // go to db or xml file to determine which file return to user
         }
    }
