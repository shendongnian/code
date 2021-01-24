    var serviceBusNamespace = "serviceBusNameSpace";
    var topicPath = "topicPath";
    var subscriptionName = "subscription name";
    var ruleName = "testrule2"; // rule name
    var sharedAccessKeyName = "xxxSharedAccessKey",
    var key = "xxxxxxM2Xf8uTRcphtbY=";
    var queueUrl = $"https://{serviceBusNamespace}.servicebus.windows.net/{topicPath}/subscriptions/{subscriptionName}/rules/{ruleName}";
    var token = GetSasToken(queueUrl, sharedAccessKeyName,key ,TimeSpan.FromDays(1));
                var body = @"<entry xmlns=""http://www.w3.org/2005/Atom"">
       <content type =""application/xml"" >
       <RuleDescription xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.microsoft.com/netservices/2010/10/servicebus/connect"">
               <Filter i:type=""SqlFilter"">
                   <SqlExpression> type = 'REPLY' AND username = 'blabla@contoso.com' </SqlExpression>
                 </Filter>
               </RuleDescription>
             </content>
           </entry>";
                var length = body.Length.ToString();
                var content = new StringContent(body, Encoding.UTF8, "application/xml");
                var _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Add("Authorization", token);
                _httpClient.DefaultRequestHeaders.Add("ContentType", "application/atom+xml");
                _httpClient.DefaultRequestHeaders.Add("Accept", "application/atom+xml");
                content.Headers.Add("Content-Length", length);
                var requestResponse =  _httpClient.PutAsync(queueUrl, content, new System.Threading.CancellationToken()).Result;
