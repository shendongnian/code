        protected void MyButton_OnClick(object sender, EventArgs e)
        {
             Label1.Text = MyTextBox.Text;
             UpdatePanel1.Update();
             ModalPopupExtender1.Show();
        }
