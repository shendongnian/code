    public class Test
    {
      public static bool FindText()
      {
        var stringsToFind = new [] { "Good", "Bad" };
        var conf = Driver.Instance.FindElement(By.Id("foo"));
        if (stringsToFind.Any(s => conf.Text.Contains(s))
        {
            return true;
        }
        throw new Exception("Text not found");
      }
    }
