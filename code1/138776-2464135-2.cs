    public class SomeClass
    {
        public bool SomeBool { get; set; }
        public bool NotSomeBool
        {
            get { return !SomeBool; }
            set { SomeBool = !value; }
        }
    }
    ...
    CheckBox1.DataBindings.Add("Checked", this.object, "NotSomeBool");
