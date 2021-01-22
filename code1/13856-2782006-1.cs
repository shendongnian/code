    public class CodedWebTest : WebTest
    {
        public override IEnumerator<WebTestRequest> GetRequestEnumerator()
        {
            WebTestRequest request1 = new WebTestRequest("http://www.google.com");
            FailValidationRule failValidation = new FailValidationRule();
            request1.ValidateResponse += new EventHandler<ValidationEventArgs>(failValidation.Validate);
            yield return request1;
        }
    }
