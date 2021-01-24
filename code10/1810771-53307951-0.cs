				using (var response = (HttpWebResponse)request.GetResponse())
				{
					using (Stream responseStream = response.GetResponseStream())
					{
						using (StreamReader streamReader = new StreamReader(responseStream))
						{
							responseString = streamReader.ReadToEnd();
						}
						Dts.Variables["User::JsonResponse"].Value = responseString;
					}
				}
