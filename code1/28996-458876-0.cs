    interface ICommand {
    string Name { get; }
    string Description { get; }
    ...
    
    classSpecific : ICommand {
    public string Name { get { return "Specific"; }}
    public string Description { get { return "Specific description"; }}
    ...
