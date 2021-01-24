     var finalResult=JsonConvert.DeserializeAnonymousType(
            yourdata,  // input
            new 
            {
              Id= 
              {
                new
                { 
                  success="", data=""
                }
              }
            }
          ); 
    console.write(finalResult.Id);// getting Id 578080
    console.write(finalResult.Id.success);
    console.write(finalResult.Id.data.type);
