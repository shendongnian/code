    class Program
    {
	static void Main(string[] args)
	{
		var b = new Book("Book Title", 2342);
		Console.WriteLine(CallMethod(b, "GetTitle", "Not Found"));
	}
	public static K CallMethod<T,K>(T a, string method, K defaultOjb)
	{
		var t = a.GetType();
		var mi = t.GetMethod(method);
		if (mi == null) return defaultOjb;
		var ret=mi.Invoke(a, new object[] {});
		return (K) ret;
	}
    }
    public class Book
    {
	private readonly string _title;
	private readonly decimal _price;
	public decimal GetPrice()
	{
		return _price;
	}
	public string GetTitle()
	{
		return _title;
	}
	public Book(string title, decimal price)
	{
		_title = title;
		_price = price;
	}
    }
