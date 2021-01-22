void Main()
{
    Dictionary<int, string> d1 = new Dictionary&lt;int, string&gt;();
    Dictionary<int, string> d2 = new Dictionary&lt;int, string&gt;();  
	
    d1.Add(1, "1");
    d1.Add(2, "2");  
    d1.Add(3, "3");  
    d2.Add(2, "2");  
    d2.Add(1, "1");  
    d2.Add(3, "3");  
	
    Console.WriteLine(d1.Keys.Except(d2.Keys).ToArray().Length);  
}
