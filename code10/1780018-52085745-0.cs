    var json = "[{\"displayorder\":2,\"oppItemID\":4,\"opportunityName\":\"Net 10\",\"title\":\"New Amazing Promotion\",\"description\":\"Amazing\",\"image\":\"imagelink\",\"opDate\":\"2018-08-09T22:00:00.937\",\"slideOrder\":0,\"status\":false,\"isCover\":false},{\"displayorder\":1,\"oppItemID\":2,\"opportunityName\":\"Simple Mobile\",\"title\":\"New promo\",\"description\":\"Amazing\",\"image\":\"imagelink\",\"opDate\":\"2018-08-09T22:00:00.937\",\"slideOrder\":0,\"status\":false,\"isCover\":false},{\"displayorder\":1,\"oppItemID\":3,\"opportunityName\":\"Simple Mobile\",\"title\":\"New Amazing Promotion\",\"description\":\"Amazing\",\"image\":\"imagelink\",\"opDate\":\"2018-08-10T22:00:00.937\",\"slideOrder\":0,\"status\":false,\"isCover\":false},{\"displayorder\":8,\"oppItemID\":5,\"opportunityName\":\"Verizon\",\"title\":\"New Amazing Promotion\",\"description\":\"Amazing\",\"image\":\"imagelink\",\"opDate\":\"2018-08-09T22:00:00.937\",\"slideOrder\":0,\"status\":false,\"isCover\":false},{\"displayorder\":8,\"oppItemID\":27,\"opportunityName\":\"Verizon\",\"title\":\"New Amazing\",\"description\":\"Amazing\",\"image\":\"imagelink\",\"opDate\":\"2018-08-22T22:00:00.937\",\"slideOrder\":0,\"status\":false,\"isCover\":false}]";
            var obj = JsonConvert.DeserializeObject<List<JSonClass>>(json);
            var transformed = obj 
                                .Select(  (value, index) => new {
                                                name = value.opportunityName,
                                                obj = new JSonClass2 {
                                                        displayorder = value.displayorder,
                                                        oppItemID = value.oppItemID,
                                                        title = value.title,
                                                        description = value.description,
                                                        image = value.image,
                                                        opDate = value.opDate,
                                                        slideOrder = value.slideOrder,
                                                        status = value.status,
                                                        isCover = value.isCover
                                                        }
                                                })
                    .GroupBy(u=>u.name)  // groups by name
                    .ToDictionary(       // use dictionary to move value from value position to key position 
                                    wrap =>wrap.Key, 
                                    wrap => wrap.Select( (v,i) => new { i, v.obj })
                    .ToDictionary(w => w.i, w => w.obj )  
                    );
                       
            Console.WriteLine(JsonConvert.SerializeObject(transformed, Formatting.Indented));
