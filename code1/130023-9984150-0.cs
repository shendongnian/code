		public void ProcessRequest(HttpContext context) {
			using (StreamWriter writer = new StreamWriter(context.Server.MapPath("/test.txt"))) {
				var token = context.Request.Form["token"];
				writer.WriteLine("Token: " + token);
				try {
					var rpx = new Rpx("my_id", "https://rpxnow.com/");
					var authInfo = rpx.AuthInfo(token);
					var doc = XDocument.Load(new XmlNodeReader(authInfo));
					writer.WriteLine(doc.Root.Descendants("displayName").First().Value);
					writer.WriteLine(doc.Root.Descendants("identifier").First().Value);
				}
				catch (Exception ex) {
					writer.WriteLine("Error: " + ex.Message);
				}
				foreach (string header in context.Request.Headers)
					writer.WriteLine(header + " - " + context.Request.Headers[header]);
			}
		}
