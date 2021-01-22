    public class User {
      public event EventHandler NameChanged = delegate { };
      public int ID { get; }
      public string Name { get; private set; }
      public void ChangeName(string newName) {
        if (newName != Name) {
          NameChanged(this, EventArgs.Empty);
        }
        Name = newName;
      }
    }
    public class UserMediator {
      User _user;
      EventHandler _eh;
      public UserMediator(User user, Action onNameChanged) {
        _user = user;
        _eh = (src, args) => onNameChanged();
        _user.NameChanged += _eh;
      }
      public void Detach() {
        _user.NameChanged -= _eh;
      }
    }
