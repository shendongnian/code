    public class Form1 : Form
    {
        protected void FindAndReplace_Click(object sender, EventArgs e) 
        {
            var findAndReplaceForm = new FindAndReplaceForm(MainText.Text);
            findAndReplaceForm.ShowDialog();
            MainText.Text = findAndReplaceForm.NewText;
        }
    }
    
    public class FindAndReplaceForm : Form
    {
        private readonly string _originalText;
        public FindAndReplaceForm(string originalText)
        {
            _originalText = originalText;
        }
        public string NewText 
        { 
            get 
            {
                return (_originalText ?? string.Empty).Replace(findMe, replaceMe);
            }
        }
    }
