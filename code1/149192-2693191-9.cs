    /*
     * Now there is only one meaning for index in this scope
     */
    ClearEmailAddressesFor(people); // the method name works like a comment now
    var index = GetIndexForSomethingElse();
    /*
     * Now index has a single meaning in the scope of this method.
     */
    private void ClearEmailAddressesFor(IList<Person> people)
    {
        for (var index = 0; index < people.Count; index++)
        {
            people[index].Email = null;
        }
    }
