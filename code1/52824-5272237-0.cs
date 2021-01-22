     public partial class Person
        {
            protected override void OnPropertyChanged(string property)
            {
                if (property == "BirthDate")
                {
                    this._BirthDate= DateTime.SpecifyKind(this._BirthDate, DateTimeKind.Utc);
                }
    
                base.OnPropertyChanged(property);
            }
    
        }
