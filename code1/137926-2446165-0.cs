    protected void Button1_Click(object sender, EventArgs e) {
    	if (FileUpload1.HasFile)
    		try {
    			FileUpload1.SaveAs("C:\\Uploads\\" + 
    				 FileUpload1.FileName);
    			Label1.Text = "File name: " +
    				 FileUpload1.PostedFile.FileName + "<br>" +
    				 FileUpload1.PostedFile.ContentLength + " kb<br>" +
    				 "Content type: " +
    				 FileUpload1.PostedFile.ContentType;
    		}
    		catch (Exception ex) {
    			Label1.Text = "ERROR: " + ex.Message.ToString();
    		}
    	else {
    		Label1.Text = "You have not specified a file.";
    	}
    }
