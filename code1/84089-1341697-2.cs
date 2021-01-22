      void Page_Load(Object sender, EventArgs e) 
      {
         // Load sample data only once, when the page is first loaded.
         if (!IsPostBack) 
         {
           dlCampChars.DataSource = CreateDataSource();
           dlCampChars.DataBind();
         }
      }
    private DataTable CreateDataSource()
    {
      // however you get your data and whatever the resulting object is
      // for example: DataTable, DataView, etc.
      DataTable dt = [relevant code here];
    
      // retrieve the user's stored DataKey
      string datakey = [retrieved datakey value from DB];
      // if stored DataKey exists loop through DataTable
      // looking for the index of the item matching the DataKey
      int itemIndex = 0;
      for (int i = 0; i < dt.Rows.Count; i++)
      {
        // check the appropriate "DataKey" column name of the current row
        if (dt.Rows["DataKey"].ToString() == datakey)
        {
          // match found, set index and break out of loop
          itemIndex = i;
          break;
        }
      }
      
      // set SelectedIndex
      dlCampChars.SelectedIndex = itemIndex;
      // now return the DataSource (ie. DataTable etc.)
      return dt;
    }
