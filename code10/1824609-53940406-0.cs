    var query = new {
      bool = new {
        must = new {
          match = new {
            field = "status",
            query = "success"
          }
        },
        filter = new {
          range = new {
            createDate = new {
              gte = "2018-01-01T00:00:00.000Z",
              lt = "2019-01-01T00:00:00.000Z"
            }
          }
        }
      }
    };
