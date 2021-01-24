c#
public class User
{
  EmailPermissions _EmailPermissions;
  public EmailPermissions 
  {
    get => _EmailPermissions ??= new EmailPermissions();
    set => _EmailPermissions = value;
  }
}
When I tried to add seed data I got that nasty exception.
The solution was to pass the **`User`** as anonymous type in its `HasData` call.
