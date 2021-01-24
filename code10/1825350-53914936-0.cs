    public StarWarsMutation(StarWarsRepository data)
    {
        Name = "Mutation";
        Field<HumanType>(
            "createOrUpdateHuman",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<HumanInputType>> {Name = "human"}
            ),
            resolve: context =>
            {
                //After conversion human.HomePlanet is null. But it was not informed, we should keep what is on the database at the moment
                var human = context.GetArgument<dynamic>("human");
                var humanDb = data.GetHuman(human["id"]);
                var json = JsonConvert.SerializeObject(human);
                JsonConvert.PopulateObject(json, humanDb);
                //On EFCore the Update method is equivalent to an InsertOrUpdate method
                return data.Update(humanDb);
            });
    }
