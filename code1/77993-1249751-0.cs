class A {
    public int Id { get; set; }
    public string Name { get; set; }
}
class B : A {
    public DateTime BirthDate { get; set; }
}
class ObjectComparer {
    public static void Show() {
        A a = new A();
        B b = new B();
        A a1 = new A();
        Console.WriteLine(ObjectComparator<A>.CompareProperties(a, b));
        Console.WriteLine(ObjectComparator<A>.CompareProperties(b, a));
        Console.WriteLine(ObjectComparator<A>.CompareProperties(a, a1));
    }
}
