    HttpClient Client { get; } = CreateHttpClient(TimeSpan.FromSeconds(10));
	public static async Task<EnrollmentStatus?> EnrollSpeaker(Stream audioStream, Guid userGuid)
	{
		Enrollment response = null;
		try
		{
			var boundryString = "Upload----" + DateTime.Now.ToString("u").Replace(" ", "");
			var content = new MultipartFormDataContent(boundryString)
			{
				{ new StreamContent(audioStream), "enrollmentData", userGuid.ToString("D") + "_" + DateTime.Now.ToString("u") }
			};
			var requestUrl = "https://westus.api.cognitive.microsoft.com/spid/v1.0/verificationProfiles" + "/" + userGuid.ToString("D") + "/enroll";
			var result = await Client.PostAsync(requestUrl, content).ConfigureAwait(false);
			string resultStr = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
			if (result.StatusCode == HttpStatusCode.OK)
				response = JsonConvert.DeserializeObject<Enrollment>(resultStr);
			return response?.EnrollmentStatus;
		}
		catch (Exception)
		{
			
		}
		return response?.EnrollmentStatus;
	}
	static HttpClient CreateHttpClient(TimeSpan timeout)
	{
		HttpClient client = new HttpClient();
		client.Timeout = timeout;
		client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
		client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //replace [Your Speaker Recognition API Key] with your Speaker Recognition API Key from the Azure Portal
		client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", [Your Speaker Recognition API Key]);
		return client;
	}
    public class Enrollment : EnrollmentBase
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public EnrollmentStatus EnrollmentStatus { get; set; }
        public int RemainingEnrollments { get; set; }
        public int EnrollmentsCount { get; set; }
        public string Phrase { get; set; }
    }
    public enum EnrollmentStatus
    {
        Enrolling
        Training,
        Enrolled
    }
