       public partial class Form1 : Form
       {
        bool _closing;
        public bool closing { get { return _closing; } }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _closing = true;
        }
     ...
      
     // part executing in another thread: 
     if (_owner.closing == false)
      { // the invoke is skipped if the form is closing
      myForm.Invoke(myForm.myDelegate, new Object[] { message });
      }
