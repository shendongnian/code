            var respStr = @"{
							name:'test',
							clients: {
								'client1': 'Bill',
								'client2': 'Steve',
								'client3': 'Ryan'
								}
							}";
			var jsonObject = JObject.Parse(respStr);
			foreach (var item in jsonObject)
			{
				var name = item.Key;
				JToken token = item.Value;
				if (token is JObject)
				{
					foreach (var clientToken in token)
					{
						if (clientToken is JProperty)
						{
							var clientStr = (clientToken as JProperty).Value;
						}
					}
				}
				if (token is JValue)
				{
					var value = token.Value<string>();
				}
			}
