    [Usage("add", "Adds an object to the list")]
    [CommandDescription("Add object", Name = "add")]
    public class AddCommand : FubuCommand<CommandInput>
    {
        public override bool Execute(CommandInput input)
        {
            State.Objects.Add(input); // add the new object to an in-memory collection
            return true;
        }
    }
