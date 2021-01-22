    public interface MDoSomething // Where M is akin to I
    {
         // Don't really need any implementation
    }
    public static class MDoSomethingImplementation
    {
         public static string DoSomething(this MDoSomething @this, string bar) { /* TODO */ }
    }
