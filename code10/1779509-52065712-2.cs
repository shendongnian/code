        public string GetAnswer(string query)
        {
            var client = new RestClient( qnaServiceHostName + "/qnamaker/knowledgebases/" + knowledgeBaseId + "/generateAnswer");
            var request = new RestRequest(Method.POST);
            request.AddHeader("authorization", "EndpointKey " + endpointKey);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{\"question\": \"" + query + "\"}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            // Deserialize the response JSON
            QnAAnswer answer = JsonConvert.DeserializeObject<QnAAnswer>(response.Content);
            // Return the answer if present
            if (answer.answers.Count > 0)
                return answer.answers[0].answer;
            else
                return "No good match found.";
        }
    }
