        private async void btnTake_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                SaveToAlbum = true,
                PhotoSize = PhotoSize.Small
            });
            var Image = ImageSource.FromStream(() => file.GetStream());
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
            // Request parameters
            queryString["mode"] = "Printed";
            var uri = "https://eastus.api.cognitive.microsoft.com/vision/v2.0/recognizeText?" + queryString;
            HttpResponseMessage response;
            var myStream = file.GetStream();
            BinaryReader binaryReader = new BinaryReader(myStream);
            var byteData = binaryReader.ReadBytes((int)myStream.Length);
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(uri, content);
            }
            string operationLocation = "";
            operationLocation = response.Headers.GetValues("Operation-Location").FirstOrDefault();
            string contentString;
            int i = 0;
            do
            {
                System.Threading.Thread.Sleep(1000);
                response = await client.GetAsync(operationLocation);
                contentString = await response.Content.ReadAsStringAsync();
                ++i;
            }
            while (i < 10 && contentString.IndexOf("\"status\":\"Succeeded\"") == -1);
            Label1.Text = JToken.Parse(contentString).ToString();
        }
