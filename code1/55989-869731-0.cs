      public class Program
      {
        const int KL_NAMELENGTH = 9;
    
        [DllImport("user32.dll")]
        private static extern long GetKeyboardLayoutName(
              System.Text.StringBuilder pwszKLID); 
    
        static void Main(string[] args)
        {
          StringBuilder name = new StringBuilder(KL_NAMELENGTH);
    
          GetKeyboardLayoutName(name);
    
          Console.WriteLine(name);
    
        }
      }
