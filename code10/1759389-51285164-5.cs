		private static MultipartFormDataContent CreateFakeMultiPartFormData()
        {
            byte[] data = { 1, 2, 3, 4, 5 };
            ByteArrayContent byteContent = new ByteArrayContent(data);
            StringContent stringContent = new StringContent(
                "blah blah",
                System.Text.Encoding.UTF8);
            MultipartFormDataContent multipartContent = new MultipartFormDataContent { byteContent, stringContent };
            return multipartContent;
        }
