    private int Server_Get_Int(){
        var task = Task.Run(async () => {
            var c = Server_Connect();
            return (await c.GetAsync("todos/set")).ResultAs<int>();
        });
    
        int result = task.Result;
        Console.WriteLine(result);
        return result;
    }
