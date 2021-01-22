    protected void Page_Load(object sender, EventArgs e)
        {
            // Get the current domain 
            var current = HttpContext.Current.Request.Url.Host;
            // We need to tell the SPSite object the URL of where our List is stored.
            // Make sure you have the right location placed after the 'current' variable
            using (SPSite spSite = new SPSite("http://"+current+"/DirectoryForLists/Lists")) 
            {
                // Returns the Web site that is located at the specified server-relative or site-relative URL.
                using (SPWeb spWeb = spSite.OpenWeb())
                {
                    //Get our list we created.
                    SPList list = spWeb.Lists["Name Of the List"];
                    // Create a new SPQuery object that will hold our CAML query.
                    SPQuery q = new SPQuery();
                    // CAML query.
                    // This allows you to controll how you receieve your data.
                    // Make the data ASC or DESC. Find more on MSDN.
                    q.Query = "<OrderBy><FieldRef Name='DESCR' Ascending='TRUE' /></OrderBy>";
                    // We put our list data into a SP list Item Collection.
                    // Notice that the CAML query is the only parameter for the GetItems() function.
                    SPListItemCollection items = list.GetItems(q);
                    // Here you can loop through your list.
                    foreach (SPListItem spItem in items)
                    {
                        // Your code here.
                        MessageBox(spItem);
                        // Get URL column
                        MessageBox(spItem["URL"]);
                        // Another Column
                        MessageBox(spItem["DateTime"]);
                    }
                }
            }
        }
