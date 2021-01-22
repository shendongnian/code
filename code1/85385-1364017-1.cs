    private static string GetUserErrorMessageOrDefault(HttpContextBase httpContext, ModelError error, ModelState modelState) {
        if (!String.IsNullOrEmpty(error.ErrorMessage)) {
            return error.ErrorMessage;
        }
        if (modelState == null) {
            return null;
        }
        // Remaining code to fetch displayed string value...
    }
