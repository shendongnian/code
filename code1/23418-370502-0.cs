    public interface CollectibleElephant { 
        long getId();
        String getName();
        long getTagId();
    }
    public class Elephant implements CollectibleElephant { ... }
    public class BabyElephant implements CollectibleElephant { ... }
   
