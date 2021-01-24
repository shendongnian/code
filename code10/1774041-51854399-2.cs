    public class Program
    {
       public static Task<int> X(int x) {
          return Task.FromResult(x);
       }
    	
       public static async Task<IEnumerable<int>> GetYAsync(IEnumerable<int> infos)
       {
          var res = await Task.WhenAll(infos.Select(info => X(info)));
          return res;
       }
    	
       public static async void Main()
       {
          var test = await GetYAsync(new [] {1, 2, 3});
          Console.WriteLine(test)	;
       }
    }
