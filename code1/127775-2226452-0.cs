    public interface IProfile { string GetName(); }
    public class Profile : IProfile
    {
        string IProfile.GetName() { return "Linh"; }
    }
