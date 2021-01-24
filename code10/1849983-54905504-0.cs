        [System.Web.Mvc.Remote(
            action: "CheckExistingDocumentCode",
            controller: "Documents",
            AdditionalFields = "DocumentId",
            HttpMethod = "POST",
            ErrorMessage = "Code already exists")]
        public string DocumentCode { get; set; }
