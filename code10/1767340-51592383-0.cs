    private async Task PostData()
    {
        if (myPushDataFilterd.Any())
        {
            var title = txtHomeworkTitle.Value.Trim();
            using (var client = new HttpClient())
            {
                for (int index = 0; index < myPushDataFilterd.Count; index++)
                {
                    var row = myPushDataFilterd[index];
                    jData.Add("moduleName", "Homework");
                    jData.Add("organizationId", ddlOrganization.SelectedValue);
                    jData.Add("studentId", studentId);
                    jGcmData.Add("to", to);
                    jGcmData.Add("data", jData);
                    api = row.ServerKeyPush;                                       
                    var url = new Uri("https://fcm.googleapis.com/fcm/send");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "key=" + api);
                    var r = await client.PostAsync(url, new StringContent(jGcmData.ToString(), Encoding.Default, "application/json"));
                }
            }
        }
    }
