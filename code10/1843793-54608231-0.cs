      class SurroundingClass
    {
        private void Button1_Click(object sender, EventArgs e)
        {
            var FullResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(WebResult);
            Newtonsoft.Json.Linq.JObject lv2 = FullResponse.Item("ModelState");
            Newtonsoft.Json.Linq.JObject lv3 = lv2.Item("");
            string DisplayResponse = FullResponse.Item("Message") + " " + lv3.Item("$values").First;
    
            MessageBox.Show(DisplayResponse);
        }
    
        public string WebResult()
        {
            return "{'$id':'1','Message':'The request is invalid.','ModelState':{'$id':'2','':{'$id':'3','$values':['Name username@gmail.com is already taken.']}}}";
        }
    }
