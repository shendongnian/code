    public void ExceuteMultipleHttpCalls()
    {
                var contentSequence1 = new StringContent("{ 'id':'anId','email':'test@valid.com'}", Encoding.UTF8, "application/json");
                var contentSequence2 = new StringContent("{ 'id':'anotherId','email':'anotherTest@valid.com'}", Encoding.UTF8, "application/json");
                var sequenceResponse = new List<Tuple<HttpStatusCode, HttpContent>>
                {
                    new Tuple<HttpStatusCode, HttpContent>(HttpStatusCode.OK, contentSequence1),
                    new Tuple<HttpStatusCode, HttpContent>(HttpStatusCode.Created, contentSequence2)
                };
                HttpClient httpClient = GetHttpClientWithHttpMessageHandlerSequenceResponseMock(sequenceResponse);
    //use this httpClient to call function where this client is called multiple times. 
}
