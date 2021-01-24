    public enum IncludeErrorDetailPolicy
    {
        // Summary:
        //     Use the default behavior for the host environment. For ASP.NET hosting, usethe value from the customErrors element in the Web.config file. 
        //     For self-hosting, use the value System.Web.Http.IncludeErrorDetailPolicy.LocalOnly.
        Default = 0,
     
        // Summary:
        //     Only include error details when responding to a local request.
        LocalOnly = 1,
        //
        // Summary:
        //     Always include error details.
        Always = 2,
        //
        // Summary:
        //     Never include error details.
        Never = 3,
    }
