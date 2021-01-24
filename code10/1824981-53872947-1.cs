        public void ComposeAndSendJson(string accountReference, string toAddress, string messageBody)
        {
            RootObject whatIwanttoSend = new RootObject();
            Message messageComposed = new Message();
            messageComposed.to = toAddress;
            messageComposed.body = messageBody;
            whatIwanttoSend.accountReference = accountReference;
            //I'm doing a pretty bad aproach but it's just to ilustrate the concept
            whatIwanttoSend.messages.toList().Add(messageComposed);
            var jsonData = JsonConvert.SerializeObject(whatIwanttoSend);
            //As you're working on async, you may need to do some working on here. In this sample i'm just calling it in Sync. 
            var ApiResponse = PostAsync("YOURENDPOINT",jsonData).Result();
            //Do something else with the response ... 
        }
        protected async Task<Task<HttpResponseMessage> PostAsync(Uri endpoint, string payload)
        {
            using (var httpClient = NewHttpClient())
            {
                //You have to tell the API you're sending JSON data
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Execute your call
                var result = await httpClient.PostAsync(endpoint, payload);
                //Basic control to check all went good.
                if (result.IsSuccessStatusCode)
                {
                    return result;
                }
                //Do some management in case of unexpected response status here... 
                return result; //Statuscode is 400 here. 
            }
        }
