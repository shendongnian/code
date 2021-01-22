    public class PersonProxy : Person {
        private PersonRepository _personRepository = new PersonRepository();
        public override IList<Child> Children {
            get {
                if (base.Children == null)
                    base.Children = _personRepository.GetChildrenForPerson(this.Id);
                return base.Children;
            }
            set { base.Children = value; }
        }
    }
