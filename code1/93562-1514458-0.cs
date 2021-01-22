		internal class RemoteAspDomain : MarshalByRefObject
		{
			public string ProcessRequest(string page, string query)
			{
				using (StringWriter sw = new StringWriter())
				{
					SimpleWorkerRequest work = new SimpleWorkerRequest(page, query, sw);
					HttpRuntime.ProcessRequest(work);
					return sw.ToString();
				}
			}
		}
