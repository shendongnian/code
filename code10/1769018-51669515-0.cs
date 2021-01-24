     public JsonResult RegisterNewMemberByJson(ReligionAndEthinicityModel RegisterData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool captchaIsvalid = IsReCaptchValid(RegisterData.cResponse);
                    if (captchaIsvalid)
                    {
    public bool IsReCaptchValid(string cResponse)
        {
            var result = false;
            var captchaResponse = cResponse;
            var secretKey = Convert.ToString(ConfigurationManager.AppSettings["RecaptchaKey"]);
            var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
            var requestUri = string.Format(apiUrl, secretKey, captchaResponse);
            var request = (HttpWebRequest)WebRequest.Create(requestUri);
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    JObject jResponse = JObject.Parse(stream.ReadToEnd());
                    var isSuccess = jResponse.Value<bool>("success");
                    result = (isSuccess) ? true : false;
                }
            }
            return result;
        }
