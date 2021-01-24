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
              gt = "2018-12-01T00:00:00.000Z"
            }
          }
        }
      }
    };
