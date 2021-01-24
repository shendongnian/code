    public PersonQuery(ShoppingData data)
    {
        Field<PersonType>( /* snip */ );
        Field<ListGraphType<PersonType>>(
            "people",
            description: "A list of people",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>>
                {
                    Name = "firstName",
                    Description = "The first name of the person"
                }),
            resolve: ctx =>
            {
                return data.GetByFirstName(ctx.GetArgument<string>("firstName"));
            });
    }
