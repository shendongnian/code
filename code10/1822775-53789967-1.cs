    namespace Audio_File_Management {
    public partial class Form1 : Form {
    public static Form1 objForm1;
        public Form1() {
            InitializeComponent();
        }
        
        public static Form1 GetForm()
        {
            if( (objForm1 == null) || objForm1.IsDisposed)
            {
               objForm1 = new Form1();
            }
            return objForm1;
        }
     }
    }
    public class Program
    {
       public static void Main() {
            Form1.GetForm().FormBorderStyle = FormBorderStyle.FixedDialog;
        }
    }
   
