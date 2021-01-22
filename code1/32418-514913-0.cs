            string address = string.Format(
                "http://foobar/somepage?arg1={0}&arg2={1}",
                Uri.EscapeDataString("escape me"),
                Uri.EscapeDataString("& me !!"));
            string text;
            using (WebClient client = new WebClient())
            {
                text = client.DownloadString(address);
            }
