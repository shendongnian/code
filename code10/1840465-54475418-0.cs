    [HttpGet]
        public List<MyApiDataDto> GetResults()
        {
            List<ApiSourceDataDto> externalApiResults = Webservice.GetResults().ToList();
            List<MyApiDataDto> myResults = new TranslationLayer().Translate(externalApiResults)
            return myResults; 
        }
