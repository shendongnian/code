        [AllowAnonymous]
        [HttpPost]
        [Route("api/CreateNewComitteeMember")]
        public Task<HttpResponseMessage> CreateNewComitteeMember()
        {
            var imageData = HttpContext.Current.Request.Params["mImage"];
            var formData = new JavaScriptSerializer()
            .Serialize<MFormData>(HttpContext.Current.Request.Params["mFormData"]);
            try
            {
                //Function to save the file and get the URL
                formData.ImageUrl = new ApplicationBussinessLayer().SaveFileInDir(imgeData);
                //Function to save data in the DB
                var saveData = await new AppicationBussinessLayer().SaveUserInfo(formData);    
            }
            catch(Exception ex)
            {
                return Request.Create(HttpStatusCode.Code, "Some error");
            }
            return Request.Create(HttpStatusCode.OK, "Data Saved");
        }
