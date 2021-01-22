        // Get all Categories - complex object response
        [OperationContract]                             // categories
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetAllCategories")]
        CategoryCollection GetAllCategories();          // SubSonic object
        [OperationContract]                             // categories - respond with a JSON object
        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetAllCategories.JSON")]
        CategoryCollection GetAllCategoriesJSON();      // SubSonic object
