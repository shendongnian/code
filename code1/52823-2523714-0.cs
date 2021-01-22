    public partial class Person {
    
      partial void OnLoaded() {
        this._BirthDate = DateTime.SpecifyKind(this._BirthDate, DateTimeKind.Utc);
      }
    }
