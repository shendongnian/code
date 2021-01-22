    [Usage("list", "List the objects we have so far")]
    [CommandDescription("List objects", Name = "list")]
    public class ListCommand : FubuCommand<NullInput>
    {
        public override bool Execute(NullInput input)
        {
            State.Objects.ForEach(Console.WriteLine);
            return false;
        }
    }
