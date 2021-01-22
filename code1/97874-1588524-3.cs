    protected void ContactsListView_ItemDataBound(object sender, ListViewItemEventArgs e)
          {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
              // Display the e-mail address in italics.
              Label EmailAddressLabel = (Label)e.Item.FindControl("EmailAddressLabel");
              // EmailAddressLabel.Font.Italic = true;
              string valueoftheControl = EmailAddressLabel.Text;  
              /* you have to get the value like this. 
                 If its a dropdown or any other use their 
                 corresponding property to get the value.*/
            }
          }
