    public string x() { ... }
    public int x() { ... }
    // ...
    
    x();  // <-- Which one did you mean? It's impossible to tell if you
          //     allow return types to be part of method overloads.
