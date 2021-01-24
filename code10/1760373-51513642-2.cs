    var aaa = null;
    await ExcecuteWithLogging(async () => 
                    aaa = await Method());
     public async Task<string> ExcecuteWithLogging(Func<Task> action)
     {
            try
            {
                await Task.Run(action);
            }
            catch (Exception ex)
            {
                // handle exception
                return null;
            }
            return "ok";
     }
