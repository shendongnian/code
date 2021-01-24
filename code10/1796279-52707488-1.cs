     webRequest.GetResponseAsync()
            .ContinueWith(antecedent =>
            {
                WebResponse response = antecedent.Result;
                reader = new StreamReader(response.GetResponseStream());
                return reader.ReadToEndAsync();
            })
