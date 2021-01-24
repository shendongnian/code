    Field<ListGraphType<PersonType>>(
        "people",
        description: "A list of people",
        arguments: new QueryArguments(
            new QueryArgument<StringGraphType>
            {
                Name = "firstName", //The parameter to filter on first name
                Description = "The first name of the person"
            },
            new QueryArgument<StringGraphType>
            {
                Name = "surname",
                Description = "The surname of the person"
            }),
        resolve: ctx =>
        {
            //You will need to write this new method
            return data.SearchPeople(
                ctx.GetArgument<string>("firstName"), 
                ctx.GetArgument<string>("surame"));
        });
