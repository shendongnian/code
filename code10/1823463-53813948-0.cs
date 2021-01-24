        public PicForm getPicForm()
        {
            if (dspForm == null)
            {
                dspForm = new PicForm();
                dspForm.FormClosed += PicForm_FormClosed;
                dspForm.Visible = true;
            }
            dspForm.Show();
            return dspForm;
        }
        private void PicForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            PicForm picForm =(PicForm)sender;
            picForm.FormClosed += PicForm_FormClosed;
            dspForm = null;
        }
