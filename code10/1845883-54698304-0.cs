    System.IO.StreamReader file = new System.IO.StreamReader("WebbApplication.App_Data.SeedData.price_detail.csv"); 
    while((line = file.ReadLine()) != null)  
    {  
        System.Console.WriteLine(line);
        //Replace with your operation below
    }
