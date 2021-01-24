        public JsonResult<IEnumerable<string>> Get(bool test)
        {
            if (test)
            {
                return this.CreateResponse(new string[] { "test1", "test2", "test3" } as IEnumerable<string>, null, System.Net.HttpStatusCode.OK);
            }
            else
            {
                return this.CreateResponse(new string[] { "test1", "test2", "test3" } as IEnumerable<string>, null, System.Net.HttpStatusCode.BadRequest);
            }
        }
