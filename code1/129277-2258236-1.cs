    public class FindAndReplaceForm
    {
        private Form1 ParentForm;
    
        public FindAndReplaceForm(Form1 parentForm)
        {
            this.ParentForm = parentForm;
            //The rest of you constructor here
        }
    
        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            string findMe = txtFind.Text;
            string replaceMe = txtReplace.Text;
        
            //The following line will search the parent form
            this.ParentForm.MainText.Replace(findMe, replaceMe);
            //this.Hide();
        }
    }
