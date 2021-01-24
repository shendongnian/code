    var aaa = null;
    await ExcecuteWithLogging(async () => 
                    aaa = await Method());
     public async Task<string> ExcecuteWithLogging(Func<Task> action)
     {
            try
            {
                Task.Run(action).Wait();
            }
            catch (Exception ex)
            {
                // handle exception
                return null;
            }
            return "ok";
     }
