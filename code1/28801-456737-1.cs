    abstract public class UniqueHeaderFooterCombination1 : DocumentGenerator
    {
      protected override void AddHeader()
      {
        Console.WriteLine("unique combination1 header");
      }
      protected override void AddFooter()
      {
        Console.WriteLine("unique combination1 footer");
      }
    }
