    public override string GetVaryByCustomString(System.Web.HttpContext context, string custom)
    {
        string CustomValue = "";
        switch (custom.ToLower())
        {
            case "company":
                CustomValue = context.Request.QueryString["company"] ?? "";
                CustomValue = CustomValue.ToLower();
                break;
        }
        return CustomValue;
    }
