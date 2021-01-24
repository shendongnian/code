    public interface IFont
    {
       Dictionary<char, Func<string[]>> Mapping { get; }
    }
    public class MyFont : IFont
    {
       public static string[] b = {
          "___.    ",
          "\\_ |__  ",
          " | __ \\ ",
          " | \\_\\ \\",
          " |___  /",
          "     \\/ "};
    
       public static string[] a = {
          "_____   ",
          "\\__  \\  ",
          " / __ \\_",
          "(____  /",
          "     \\/ "};
    
       public Dictionary<char, Func<string[]>> Mapping { get; } 
                 = new Dictionary<char, Func<string[]>>{
                       { 'b', () => b},
                       { 'a', () => a}};     
    }
