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
This will allow to have many `Package` objects for one company. The only drawback is that you have to ask for changing it to an array there as well, but for considering best practices that would do best as package numbers do not seem to be required. Ideally you would have JSON payload received as:
{
      "company": "ABC Inc.",
      "packages": [
        {
          "name": "Foo",
          "price": 1000
        },
        {
          "name": "Bar",
          "price": 2000
        },
        {
          "name": "Another",
          "price": 3000
        }
    ]
}
And maybe get an Id as well if `name` is not unique.
