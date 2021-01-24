`
private string getFbAccountID(string facebookurl)
{
    using (var webClient = new System.Net.WebClient())
    {
        var formValues = new System.Collections.Specialized.NameValueCollection
        {
            { "page_url", facebookurl }
        };
        var responseBytes = webClient.UploadValues(
            "https://codeofaninja.com/tools/get-facebook-id-answer.php",
            formValues
            );
        return System.Text.Encoding.UTF8.GetString(responseBytes);
    }
}
`
