    protected void Page_PreRender(object sender, EventArgs e)
    {
        //define the script
        string script = @"
    
        function validateAlbumName(oldName, textBoxId) {
        
            //get the textbox and its new name
            var newName = document.GetElementById(textBoxId).value;
    
            //compare the values 
            if (newName === oldName) {
                //if the name hasn't changed, 
                alert('You must change the name of the album');
                return false;
            }
           
            return confirm ('Are you sure you want to save the playlist ' + newName);  
        }
      
        ";
    
        //register the client script, so that it is available during the first page render
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "SaveAsValidation", script);
    
        //add the on client click event, which will validate the form fields on click the first time.
        btnSaveAs.OnClickClick = string.Format("return validateAlbumName('{0}','{1}');", txtAlbumName.Text, txtAlbumName.ClientID);
    
    }
