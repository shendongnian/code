	if (FileUpload1.HasFile == true) {
		string FileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);
		if (FileExtension.ToLower != ".jpg") {
			lblMessage.ForeColor = System.Drawing.Color.Red;
			lblMessage.Text = "Please select .jpg image file to upload";
		} else {
			int FileSize = FileUpload1.PostedFile.ContentLength;
			if (FileSize > 1048576) {
				lblMessage.ForeColor = System.Drawing.Color.Red;
				lblMessage.Text = "File size (1MB) exceeded";
			} else {
				string FileName = System.IO.Path.GetFileName(FileUpload1.FileName);
				string ServerFileName = Server.MapPath("~/Images/Folder1/" + FileName);
				if (System.IO.File.Exists(ServerFileName) == false) {
					FileUpload1.SaveAs(Server.MapPath("~/Images/Folder1/") + FileUpload1.FileName);
					lblMessage.ForeColor = System.Drawing.Color.Green;
					lblMessage.Text = "File : " + FileUpload1.FileName + " uploaded successfully";
				} else {
					lblMessage.ForeColor = System.Drawing.Color.Red;
					lblMessage.Text = "File : " + FileName.ToString() + " already exsist";
				}
			}
		}
	} else {
		lblMessage.ForeColor = System.Drawing.Color.Red;
		lblMessage.Text = "Please select a file to upload";
	}
