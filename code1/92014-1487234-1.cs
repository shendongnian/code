List&lt;Person&gt; list = new List&lt;Person&gt;()
{
    new Person() { FirstName = "Magic", LastName = "Johnson" },
    new Person() { FirstName = "Michael", LastName = "Jordon" },
    new Person() { FirstName = "Larry", LastName = "Bird" }
};
var value = list.Join(", ", p => p.FirstName);
// value is "Magic, Michael, Larry"
