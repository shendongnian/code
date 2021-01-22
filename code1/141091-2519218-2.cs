    public class MainForm : Form
    {
        void SomeMethod()
        {
             OtherClass otherClass = new OtherClass(this.TextToBox);
    
             otherClass.SomePublicMethod();
        }
    }
