    var debugValues = new DebugKeyValueDict
                      {
                           { "Billing Address", billingAddress }, 
                           { "CC Last 4", card.GetLast4Digits() },
                           { "Response.Success", updateResponse.Success }
                      });
