    try
    {
        if (response.IsSuccessStatusCode)
        {
            var responseContent = response.Content.ReadAsStringAsync().Result;
    
            var QnAMakerResponse = JsonConvert.DeserializeObject<Microsoft.Bot.Builder.CognitiveServices.QnAMaker.QnAMakerResults>(responseContent);
                        
            if (QnAMakerResponse.Answers != null)
            {
                var answer = QnAMakerResponse.Answers.First().Answer;
                await context.PostAsync(answer);
            }
        }
    }
    catch (Exception e)
    {
    
    }
