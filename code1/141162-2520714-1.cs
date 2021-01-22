    public interface IVocalizer { string Talk(); }
    public class Doorbell : IVocalizer {
      public string Talk() { return "Ding-dong!" }
    }
    public class Pokemon : IVocalizer {
      public string Talk() {
        var name = this.GetType().ToString();
        return (name + ", " + name + "!").ToUpper(); } // e.g., "PIKACHU, PIKACHU!"
    }
    public class Human : IVocalizer {
      public string Talk() { return "Hello!"; }
    }
