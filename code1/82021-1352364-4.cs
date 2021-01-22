    private static void TestWithTryCatch(){
        try{
            Console.WriteLine("SIN(1) = {0}", Math.Sin(1)); 
        }
        catch (Exception ex){
            Console.WriteLine(ex);
        }
    }
