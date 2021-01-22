        StringBuilder HttpInputStream;
        public void ProcessRequest(HttpContext context)
        {
	        JsonOutputStream = new StringBuilder();
	        GetInputStream(context);
           // the data will be in the HttpInputStream now
           // What you might want to do it to use convert it to a .Net class ie,
           // This is using Newtonsoft JSON
           // JsonConvert.DeserializeObject<JsonMessageGet>(HttpInputStream.ToString());
            
        }
		private void GetInputStream(HttpContext context)
		{
			using (Stream st = context.Request.InputStream)
			{
				byte[] buf = new byte[context.Request.InputStream.Length];
				int iRead = st.Read(buf, 0, buf.Length);
				HttpInputStream.Append(Encoding.UTF8.GetString(buf));
			}
		}
