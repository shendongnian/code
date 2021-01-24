      [System.Web.Http.HttpDelete]
            public string Delete([FromUri] int ID, [FromBody] String name)
            {
                return "Delete Operation" + "ID:- " + ID + "Name:- " + name;
            }
