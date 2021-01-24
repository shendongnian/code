        var finalResult=JsonConvert.DeserializeAnonymousType(
                json_str,  // input
                new 
                {
                  Id= 
                  {
                    new
                    { 
                       b=new[], o=new[]
                    }
                  }
                }
              ); 
        
        foreach(var id in finalResult.Id)
        {
        console.write(id); // gives ids like 23521952
        console.write(id.b[0]) // gives first elemnt in 'b' array
        }
