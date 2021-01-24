        var v = new { email = "test1@yahoo.com", password = "fdsafsdfsdf" };
        var request = new GraphQLRequest
        {
            Query = @"mutation customerCreate($input: CustomerCreateInput!) {
              customerCreate(input: $input) {
                userErrors {
                  field
                  message
                }
                customer {
                  id
                }
              }
            }",
            Variables = new
            {
                input = v
            }
   
        };
