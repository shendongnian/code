	string jsonText = @"{
				'name': 'foo',
				'settings': {
					'settings1': true,
					'settings2': 1
					}
				}";
    JObject jObj = JObject.Parse(jsonText);
    var setting = jObj.Descendants()
				   	.OfType<JProperty>()
					.Where(p => p.Name == "settings")
					.First()
					.Value.ToObject<Settings>();
