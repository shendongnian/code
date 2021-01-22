        //
        // GET: /FileManager/GetUploadForm/?uploadAction=actionName&modelID=1234&multipleFiles=true
        public class GetUploadFormDTO
        {
            public string PostUrl { get; set; }
            public int ModelID { get; set; }
            public bool MultipleFiles { get; set; }
        }
        [KsisAuthorize()]
        public ActionResult GetUploadForm(string postUrl, string modelID, string multipleFiles)
        {
            GetUploadFormDTO model =
                new GetUploadFormDTO()
                {
                    PostUrl = postUrl,
                    ModelID = Convert.ToInt32(modelID),
                    MultipleFiles = Convert.ToBoolean(multipleFiles)
                };
            return PartialView("UploadFormPartial", model);
        }
