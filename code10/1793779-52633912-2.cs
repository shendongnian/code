    <set-body>@{
        var body = context.Request.Body.As<JObject>(true);
        body["field1"] = System.Net.WebUtility.HtmlDecode((body["field1"] ?? "").ToString());
        return body.ToString();
    }</set-body>
