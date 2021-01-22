`
public class PersonSearch
{
    public PersonSearchCriteria
    {
        string FirstName {get; set;}
        string LastName {get; set;}
    }
    public PersonSearchResult
    {
        string FirstName {get;}
        string MiddleName {get;}
        string LastName {get;}
        string Quest {get;}
        string FavoriteColor {get;}
    }
    public static List<PersonSearchResult> Run(PersonSearchCriteria criteria)
    {
        // create a query using the given criteria
        // run the query
        // return the results 
    }
}
public class PersonSearchTester
{
    public void Test()
    {
        PersonSearch.PersonSearchCriteria criteria = new PersonSearch.PersonSearchCriteria();
        criteria.FirstName = "George";
        criteria.LastName  = "Washington";
        List<PersonSearch.PersonSearchResults> results = 
            PersonSearch.Run(criteria);
    }
}
`
