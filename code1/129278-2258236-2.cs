    public class FindAndReplaceForm
    {
        private Form1 MainForm;
    
        public FindAndReplaceForm(Form1 parentForm)
        {
            this.MainForm = parentForm;
            //The rest of you constructor here
        }
    
        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            string findMe = txtFind.Text;
            string replaceMe = txtReplace.Text;
        
            //The following line will search the parent form
            this.MainForm.MainText.Replace(findMe, replaceMe);
            //this.Hide();
        }
    }
