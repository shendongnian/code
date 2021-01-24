    public class MyEntity
    {
        public string MySchool { get; set; }
         
        [NotMapped] // <-- This tell EF that this property is not mapped to the database.
        public School? MyShcoolEnum
        {
            get
            {
                // Getting the value of this property depends on the value of the database
                // which is stored into MySchool property.
                switch (MySchool)
                {
                    case "D": return School.DVB;
                    case "A": return School.AVD;
                    case "B": return School.ASB;
                    default: return null;
                }
            }
            set
            {
                // When setting this property you automatically update the value of MySchool property
                switch (value)
                {
                    case School.DVB: this.MySchool = "D";
                        break;
                    case School.AVD: this.MySchool = "A";
                        break;
                    case School.ASB: this.MySchool = "B";
                        break;
                    default: this.MySchool = null;
                        break;
                }
            }
        }
    }
