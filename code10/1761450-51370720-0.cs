    using System.Threading.Tasks;
    public static async Task WriteSlowly(string word, TimeSpan delay = default) 
    {  		
        if(delay == default) delay = TimeSpan.FromSeconds(1);
        Console.Write(word);
        await Task.Delay(delay);
    }
