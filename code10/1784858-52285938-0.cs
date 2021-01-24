    public static HttpWebResponse CreateRequestWithResponse(string responseContent)
    {
        var response = new Mock<HttpWebResponse>(MockBehavior.Loose);
        var responseStream = new MemoryStream(Encoding.UTF8.GetBytes(responseContent));
        response.Setup(c => c.StatusCode).Returns(HttpStatusCode.OK);
        response.Setup(c => c.ContentType).Returns("text/xml;charset=\"utf-8\"");
        response.Setup(c => c.GetResponseStream()).Returns(responseStream);
        HttpWebResponse result = response.Object;
        // Set private field behind CharacterSet property
        var prop = typeof(HttpWebResponse).GetField("m_CharacterSet", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        prop.SetValue(result, "utf-8");
        // Set private field used in CharacterSet getter
        prop = typeof(HttpWebResponse).GetField("m_HttpResponseHeaders", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        prop.SetValue(result, new WebHeaderCollection());
        return result;
    }
