    public ActionResult MigrateSendGridTemplates() {
        //https://sendgrid.com/docs/API_Reference/Web_API_v3/Transactional_Templates/templates.html
        //https://sendgrid.com/docs/API_Reference/Web_API_v3/Transactional_Templates/versions.html
        var fromClient = new SendGridClient("full access api key"); //full access key
        var toClient = new SendGridClient("full access api key"); //full access key - assume blank slate
        //fetch all existing templates
        var templatesRaw = fromClient.RequestAsync(SendGridClient.Method.GET, null, null, "templates").Result;
        var templates = templatesRaw.DeserializeResponseBody(templatesRaw.Body);
        var templatesEnumerable = ((IEnumerable)templates.First().Value).Cast<dynamic>().Reverse();
        foreach (var template in templatesEnumerable)
        {
            //fetch template with versions attached
            var templateWithVerisonRaw = fromClient.RequestAsync(SendGridClient.Method.GET, null, null, $"templates/{template.id}").Result;
            var templateWithVersion = templateWithVerisonRaw.DeserializeResponseBody(templateWithVerisonRaw.Body);
            //create template on the new account
            var templateNewRaw = toClient.RequestAsync(SendGridClient.Method.POST, templateWithVerisonRaw.Body.ReadAsStringAsync().Result, null, "templates").Result;
            //test if template has any versions
            //this code is a bit naive and assumes there is only one version attached to each template
            var activeVersion = ((IEnumerable)templateWithVersion["versions"]).Cast<dynamic>().FirstOrDefault();
            if (activeVersion == null)
                continue; //this template does not have any versions to migrate
            //create template version on new account
            var templateNewId = templateNewRaw.DeserializeResponseBody(templateNewRaw.Body)["id"];
            var templateSerialized = JsonConvert.SerializeObject(activeVersion, Formatting.None);
            var templateVersionNewRaw = toClient.RequestAsync(SendGridClient.Method.POST, templateSerialized, null, $"templates/{templateNewId}/versions").Result;
        }
        return Content($"Processed {templatesEnumerable.Count()} templates.");
    }
