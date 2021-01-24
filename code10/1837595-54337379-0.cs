public class Rootobject
{
    public string company { get; set; }
    public List<Package> packages { get; set; }
}
And your Package class:
public class Package
{
    public string code { get; set; }
    public string name { get; set; }
    public int price { get; set; }
} 
This will allow to have many `Package` objects for one company. The only drawback is that you have to process your JSON slightly more – or ask for changing it to an array there as well – but the effort is worth.
