    static void Main() {
        try {
            Console.WriteLine("outer try");
            DoIt();
        } catch {
            Console.WriteLine("outer catch");
            // swallow
        } finally {
            Console.WriteLine("outer finally");
        }
    }
    static void DoIt() {
        try {
            Console.WriteLine("inner try");
            int i = 0;
            Console.WriteLine(12 / i); // oops
        } catch (Exception e) {
            Console.WriteLine("inner catch");
            throw e; // or "throw", or "throw anything"
        } finally {
            Console.WriteLine("inner finally");
        }
    }
