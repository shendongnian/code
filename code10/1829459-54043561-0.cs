    _btnAdd.Click += async (sender, args) => {
        string sUrl = "http://192.168.43.31/Service1.svc/insertIntoTableAdvertise";
        string sContentType = "application/json";
        JObject oJsonObject = new JObject();
        oJsonObject.Add("TxtGroup", _edtAdvGrouping.Text);
        oJsonObject.Add("TxtTitle", _edtTitle.Text);
        oJsonObject.Add("TxtDate", "0");
        oJsonObject.Add("TxtLocation","شاهین");
        oJsonObject.Add("TxtNumber", _edtNumber.Text);
        oJsonObject.Add("TxtPrice", _edtPrice.Text);
        oJsonObject.Add("TxtExpression", _edtExpression.Text);
        try {
            var content = new StringContent(oJsonObject.ToString(), Encoding.UTF8, sContentType);
            var response = await httpClient.PostAsync(sUrl, content);
            var responseContent = await response.Content.ReadAsStringAsync();
            Toast.MakeText(this, responseContent, ToastLength.Short).Show();
        } catch (Exception ex) {
            Toast.MakeText(this, ex.Message.ToString(), ToastLength.Short).Show();
        }
    }
