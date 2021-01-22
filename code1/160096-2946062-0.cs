		public static string GetWebPage(Uri uri) {
			if ((uri == null)) {
				throw new ArgumentNullException("uri");
			}
			using (var request = new WebClient()) {
				//Download the data
				var requestData = request.DownloadData(uri);
				//Return the data by encoding it back to text!
				return Encoding.ASCII.GetString(requestData);
			}
		}
