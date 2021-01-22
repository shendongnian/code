      public interface Iconsole
        {
           void WriteToConsole(string msg);
        }
    
    
    
     public class FakeConsole : Iconsole
        {
            public bool IsCalled = false;
    
            public void WriteToConsole(string msg)
            {
                IsCalled = true;
            }
        }
