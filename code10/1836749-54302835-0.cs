            public class AntennaItems
        {
            public int sector { get; set; }
            public int position { get; set; }
            public string qty { get; set; }
            public string model { get; set; }
        }
        public HttpResponse ParseJson()
        {
            string requestBodyString = await new StreamReader(req.Body).ReadToEndAsync();
            var newJsonString = @"{root:" + requestBodyString + @"}";
            List<string> modelList = new List<string>();
            var jsonObj = JsonConvert.DeserializeObject<List<AntennaItems>>(newJsonString);
            foreach (var elem in jsonObj)
            {
                modelList.Add(elem.model);
            }
            return new OkObjectResult($"modelList = {modelList}");
        }
