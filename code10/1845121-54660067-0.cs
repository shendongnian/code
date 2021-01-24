        class Customer
        {
            List<Vacation> vacationDays {get; set;}
        }
        public class Vacation : IEquatable<Vacation>
        {
            public string Name { get; set; }
            public int VacationId { get; set; }
            public override string ToString()
            {
                return "ID: " + VacationId + "   Name: " + Name;
            }
            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                Vacation objAsVacation = obj as Vacation;
                if (objAsVacation == null) return false;
                else return Equals(objAsVacation);
            }
            public override int GetHashCode()
            {
                return VacationId;
            }
            public bool Equals(Vacation other)
            {
                if (other == null) return false;
                return (this.VacationId.Equals(other.VacationId));
            }
            // Should also override == and != operators.
        }
