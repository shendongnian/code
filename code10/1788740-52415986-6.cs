    protected void Call_Desc(object sender, EventArgs e)
    {
            string mainTextBox = "ItmCde";
            string secondaryTextBox = "Desc";
            
            // Get a reference to the ContentPlaceHolder
            ContentPlaceHolder MainContent = this.Master.FindControl("MainContent") as ContentPlaceHolder;
            int ix = 0, index = 0; 
            if ((sender as TextBox) != null)
            {
                ix = (sender as TextBox).ID.IndexOf(mainTextBox);
                if (ix != -1)
                {
                    int.TryParse((sender as TextBox).ID.Substring(ix + mainTextBox.Length), out index);
                    secondaryTextBox = index > 0 ? secondaryTextBox + index : secondaryTextBox;
                    mainTextBox = index > 0 ? mainTextBox + index : mainTextBox;
                    (MainContent.FindControl(secondaryTextBox) as TextBox).Text = (MainContent.FindControl(mainTextBox) as TextBox).Text;
                }
            }
        }
 
