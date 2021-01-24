     public static (Microsoft.AspNetCore.Http.HttpContext, Guid) ParseTenantIDToContext(Microsoft.AspNetCore.Http.HttpContext context)
        {
            System.Guid tenantGuid = System.Guid.Empty;
            if (context.Request.Path.ToString().Split('/').Length > 3 && context.Request.Path.ToString().ToLower().Contains("odata"))
            {
                bool isValidGUID = System.Guid.TryParse(context.Request.Path.ToString().Split('/')[3], result: out tenantGuid);
                if (isValidGUID)
                {
                    context.Request.Path = context.Request.Path.Value.Replace(context.Request.Path.ToString().Split('/')[3], "tenantId");
                    context.Items["tenantId"] = tenantGuid.ToString();
                    context.Request.Headers.Remove("tenantId");
                    context.Request.Headers.Append("tenantId", tenantGuid.ToString());
                }
            }
            return (context, tenantGuid);
        }
