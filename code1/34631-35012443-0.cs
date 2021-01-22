    //in your model 
    public partial class Profile
    {
    	[DisplayName("Image Upload")]
    	[DataType(DataType.Upload)] 
    	public HttpPostedFileBase FileUpload { get; set; }
    }
    
    
    
    // in your view
    @model ProjName.Blabla.Profile
    
    @using (Html.BeginForm("Edit", "Profile", FormMethod.Post, new { enctype = "multipart/form-data" }))
    {
    	<input type="file" name="FileUpload" id="FileUpload" value="Choose File" class="form-control" />
    	<input type="submit" value="Save" class="btn btn-default" />
    }
