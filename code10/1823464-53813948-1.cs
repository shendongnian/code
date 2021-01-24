        public PicForm getPicForm()
        {
            if (dspForm == null || dspForm.Disposing || dspForm.IsDisposed)
            {
                dspForm = new PicForm();
                dspForm.Visible = true;
            }
            dspForm.Show();
            return dspForm;
        }
