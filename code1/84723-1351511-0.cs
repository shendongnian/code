    public partial class BindingListChangedForm : Form {
        BindingList&lt;Person&gt; people = new BindingList&lt;Person&gt;();
        Action&lt;Person&gt; personAdder;
        public BindingListChangedForm() {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = true;
            this.bindingSource1.DataSource = this.people;
            this.personAdder = this.PersonAdder;
        }
        private void button1_Click(object sender, EventArgs e) {
            Thread t = new Thread(this.GotANewPersononBackgroundThread);
            t.Start();
        }
        // runs on the background thread.
        private void GotANewPersononBackgroundThread() {
            Person person = new Person { Id = 1, Name = "Foo" };
            //Invokes the delegate on the UI thread.
            this.Invoke(this.personAdder, person);
        }
        //Called on the UI thread.
        void PersonAdder(Person person) {
            this.people.Add(person);
        }
    }
    public class Person {
        public int Id { get; set; }
        public string Name { get; set; }
    }
