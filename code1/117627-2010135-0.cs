    public partial class Form1 : Form {
        private Person p = new Person( );
        public Form1( ) {
            
            InitializeComponent( );
            comboBox1.DataSource = Enum.GetValues( typeof( Gender ) );
            textBox1.DataBindings.Add( "Text", p, "Name", false, DataSourceUpdateMode.OnPropertyChanged );
            comboBox1.DataBindings.Add( "SelectedItem", p, "Gender", false, DataSourceUpdateMode.OnPropertyChanged );
            label1.DataBindings.Add( "Text", p, "Name", false, DataSourceUpdateMode.Never );
            label2.DataBindings.Add( "Text", p, "Gender", false, DataSourceUpdateMode.Never );
        
        }
        private void Form1_Load( object sender, EventArgs e ) {
            // yeah, that's right i voted for him,
            // go ahead and downvote me
            p.Name = "John McCain";
            p.Gender = Gender.Male;
        }
        private void Form1_Click( object sender, EventArgs e ) {
            p.Name = "Sarah Palin";
            p.Gender = Gender.Female;
        }
    }
    public enum Gender {
        Male,
        Female
    }
    public class Person : INotifyPropertyChanged {
        private string name;
        private Gender gender;
        public string Name
        {
            get { return name; }
            set {
                name = value;
                PropertyChanged( this, new PropertyChangedEventArgs( "Name" ) );
            }
        }
        public Gender Gender {
            get { return gender; }
            set {
                gender = value;
                PropertyChanged( this, new PropertyChangedEventArgs( "Gender" ) );
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate {};
    } 
