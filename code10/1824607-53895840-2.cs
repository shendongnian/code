    new {
        query = new {
            bool = new {
                must = new {
                    term = new {
                        status = "success"
                    }
                },
                filter = new {
                    range = new {
                        date = new { gte = "2018-12-22T00:00:00.000Z" }
                    }
                }
            }
        }
    }
