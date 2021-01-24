        [HttpGet]
        public int Get()
        {
            int validationToken = Convert.ToInt32(HttpContext.Request.Query["validationToken"]);
            return validationToken;
        }
        [HttpPost]
        public void Post([FromBody]JObject rawBody)
        {
           
                using (TheoDBContext db = new TheoDBContext())
                {
                    var jsonData = rawBody["data"];
                    string name = rawBody["fromUserName"].ToString();
                    string title = jsonData["title"].ToString();
                    Kaizala newKaizala = new Kaizala();
                    newKaizala.Name = name;
                    newKaizala.Question = title;
                    newKaizala.Answer = "yes";
                    db.Kaizala.Add(newKaizala);
                    db.SaveChanges();
                }
            
          
        }
