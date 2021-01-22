    public void Main()
        {
            // Post the web page.
            try
            {
                // Set variables.
                bool fireAgain = true;
                Uri WebPageURI = new Uri("http://online.wsj.com/mdc/public/page/2_3020-moneyrate.html");
                // Post the web page.
                WebRequest request = WebRequest.Create(WebPageURI);
                request.Timeout = (1000 * 60 * 60);
                request.Method = "POST";
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string Output = reader.ReadToEnd();
                Dts.Variables["wall_street_journal_str"].Value = Output;
                Dts.Events.FireInformation(0, "WebRequest:", WebPageURI.ToString(), "", 0, ref fireAgain);
                Dts.Events.FireInformation(0, "WebResponse:", Output, "", 0, ref fireAgain);
            }
            catch (WebException ex)
            {
                Dts.Events.FireError(0, "Error:", ex.Message, "", 0);
            }
            
            // Return success.
            Dts.TaskResult = (int)ScriptResults.Success;
        }
