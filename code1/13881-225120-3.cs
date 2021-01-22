    public abstract class MudObject
    {
        MudObject ContainedBy { get; set; }
        MudObjectList Contains { get; set; }
    }
