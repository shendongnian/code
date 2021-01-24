    static void Main(string[] args)
        {
            string jsonText = @"
                              {
                                ""PropertyOne"": ""PropOne"",
                                ""PropertyTwo"": ""PropTwo"",
                                ""PropertyThree"": ""PropThree""
                            }";
            string jsonText2 = @"
                            {
                                ""MyObject"": {
                                    ""PropertyOne"": ""PropOne"",
                                    ""PropertyTwo"": ""PropTwo"",
                                    ""PropertyThree"": ""PropThree""
                                   }
                            }";
            var JsonObj = JObject.Parse(jsonText);
            var JsonObj2 = JObject.Parse(jsonText2);
            JObject MyObject = JsonObj as JObject;
            MyObject.Add("MyObject", JsonObj2["MyObject"]);
            Console.WriteLine(JsonObj.ToString());
    }
