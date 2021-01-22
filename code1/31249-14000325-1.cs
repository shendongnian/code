    var debugValues = new Dictionary<string, object>
                      {
                           { "Billing Address", billingAddress }, 
                           { "CC Last 4", card.GetLast4Digits() },
                           { "Response.Success", updateResponse.Success }
                      });
