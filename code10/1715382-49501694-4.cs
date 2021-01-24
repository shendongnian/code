            [HttpGet]
            [ActionInjectDateTimeFromUnixActionWebApiFilter]
            [Route("something1")]
            public IHttpActionResult GetSomething1()
            {
                return
                    Ok(
                        new
                        {
                            unix = 1267480860,
                            some_int = 2,
                            obj = new
                            {
                                description = "Yah Right"
                            },
                            items = new List<object> {
                                new {
                                    id = 1,
                                    name = "dude",
                                    unix2 = 1403473486
                                }
                            }
                        });
            }
    
            [HttpGet]
            [ActionInjectDateTimeFromUnixActionWebApiFilter]
            [Route("something2")]
            public Object GetSomething2()
            {
                return new
                        {
                            unix = 1267480860,
                            some_int = 2,
                            obj = new
                            {
                                description = "Yah Right"
                            },
                            items = new List<object> {
                                new {
                                    id = 1,
                                    name = "dude",
                                    unix2 = 1403473486
                                }
                            }
                        };
            }
