    public abstract class PrinterFactory 
    {
       public static PrinterFactory GetInstance(string instanceType) {
           switch (instanceType) {
               case "Nadelbaum": return new Nadelbaum();
               case "Laubbaum": return new Laubbaum();
               // etc
           }
       }
    }
