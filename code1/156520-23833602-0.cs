        public static string UnPrettyJson(this string s)
        {
            try
            {
                // var jsonObj = Json.Decode(s);
                // var sObject = Json.Encode(value);   dont work well with array of strings c:['a','b','c']
                object jsonObj = JsonConvert.DeserializeObject(s);
                return JsonConvert.SerializeObject(jsonObj, Formatting.None);
            }
            catch (Exception e)
            {
                throw new Exception(
                    s + " Is Not a valid JSON ! (please validate it in http://www.jsoneditoronline.org )", e);
            }
        }
