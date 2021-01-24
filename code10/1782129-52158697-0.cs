     public static void main() -->{
        test t1 = new test(1), t2 = new test(2); //Line 1
        t1.next = t2; //Line 2
        t2.next = t1; //Line 3
        t2 = null; //Line 4
        Console.Write(t1.next.next.next.......data) // Line 5
    }<--
