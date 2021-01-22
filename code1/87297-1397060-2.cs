    /// <summary>
    /// Adds another level of HTML list and list items to a string
    /// </summary>
    /// <param name="str">The string to add</param>
    /// <param name="liStrings">The list of strings at this level to add</param>
    /// <param name="iTabIndex">The current number of tabs indented from the left</param>
    public void GenerateHTML( System.Text.StringBuilder str, List<string> liStrings, int iTabIndex) {
       //add tabs to start of string
       this.AddTabs(str, iTabIndex);
            
       //append opening list tag
       str.AppendLine(OPEN_LIST_TAG);
            
       foreach (string strParent in liStrings) {
          //add tabs for list item
          this.AddTabs(str, iTabIndex + 1);
               
          //if there are child strings for this string then loop through them recursively
          if (this.GetChildStrings(strParent).Count > 0) {
             str.AppendLine(OPEN_LIST_ITEM_TAG + strParent);
             GenerateHTML(str, this.GetChildStrings(strParent), iTabIndex + 2);
                   
             //add tabs for closing list item tag
             this.AddTabs(str, iTabIndex + 1);
             str.AppendLine(CLOSE_LIST_ITEM_TAG);
          }
          else {
             //append opening and closing list item tags
             str.AppendLine(OPEN_LIST_ITEM_TAG + strParent + CLOSE_LIST_ITEM_TAG);
          }
       }
           
       //add tabs for closing list tag
       this.AddTabs(str, iTabIndex);
       //append closing list tag
       str.AppendLine(CLOSE_LIST_TAG);
    }
        
          
