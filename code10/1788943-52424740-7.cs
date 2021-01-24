    [HttpGet]
            [Route("GetValue")]
            [Route("GetValue/{name}/{surname}")]
            public string GetValue(string name,string surname)
            {
                return "Hello " + name + " " + surname;
            }
