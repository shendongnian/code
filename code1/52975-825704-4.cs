    using System;
    using System.Windows.Forms;
    public class PersonForm : Form
    {
        private readonly Person myPerson;
        protected virtual Person MyPerson 
        {
            get
            {
                return this.myPerson;
            }
        }
        private PersonForm()
        {
        }
        public PersonForm(Person person)
        {
            this.myPerson = person;
        }
    }
