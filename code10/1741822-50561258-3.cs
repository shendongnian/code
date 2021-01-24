       dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
       Type typeOfDynamic = data.GetType();
       if( typeOfDynamic.GetProperties().Where(p => p.Name.Equals("PKR_PKR")).Any())
       {
         console.WriteLine(data.PKR_PKR.val); 
       }
       else if( typeOfDynamic.GetProperties().Where(p => p.Name.Equals("USD_PKR")).Any())
       {
         console.WriteLine(data.USD_PKR.val); 
       }
    else if( typeOfDynamic.GetProperties().Where(p => p.Name.Equals("EUR_PKR")).Any())
       {
         console.WriteLine(data.EUR_PKR.val); 
       }
