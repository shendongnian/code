    public PersonQuery(ShoppingData data)
    {
        Field<PersonType>( /* snip */ );
        //Note this is now returning a list of persons
        Field<ListGraphType<PersonType>>(
            "people", //The new field name
            description: "A list of people",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>>
                {
                    Name = "firstName", //The parameter to filter on first name
                    Description = "The first name of the person"
                }),
            resolve: ctx =>
            {
                //You will need to write this new method
                return data.GetByFirstName(ctx.GetArgument<string>("firstName"));
            });
    }
