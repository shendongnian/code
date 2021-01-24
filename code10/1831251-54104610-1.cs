    class C { public static int I = 1; }
    typeof(B).TypeInitializer != null // true
    typeof(B).GetConstructors(BindingFlags.Static | BindingFlags.NonPublic).Length == 1 // true
    class D { public static int P { get; set; } = 1; }
    typeof(B).TypeInitializer != null // true
    typeof(B).GetConstructors(BindingFlags.Static | BindingFlags.NonPublic).Length == 1 // true
