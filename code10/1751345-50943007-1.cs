         var data = JsonConvert.DeserializeObject<JsonModel>("JsonData");
                    var result = data.Results;
    //Loop as appropriate, using index 0 for testing
                    string AuthorShip = result[0].Authorship;
                    string Origin = result[0].Origin;
                    string parent = result[0].Parent;
