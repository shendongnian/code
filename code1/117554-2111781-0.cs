    [Export(typeof(BUsers))] 
    public class EditProfile : BUsers
    {
    [ImportingConstructor]
    public EditProfile(EditProfileParameters ctorPars)
    : this(ctorPars.Method, ctorPars.Version) {}
    public EditProfile(string Method, string Version)
    {
        Version = "2";
        Action = "Edit";
        TypeName = "EditProfile";
    }
