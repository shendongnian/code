    var repositoryItemCheckEdit1 = new  DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
    repositoryItemCheckEdit1.AutoHeight = false;
	repositoryItemCheckEdit1.Caption = "Audited";
	repositoryItemCheckEdit1.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined; // <-- important!!!!!
  	repositoryItemCheckEdit1.Images = imageList; // <--- put an image control on your form and add red and green icons in it
	repositoryItemCheckEdit1.ImageIndexChecked = 0; // <-- depends on your indexes in imageControl
	repositoryItemCheckEdit1.ImageIndexUnhecked = 1;  // <-- depends on your indexes in imageControl
	repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
			
		
	colAUDITSTATUS.ColumnEdit = this.repositoryItemCheckEdit1;
