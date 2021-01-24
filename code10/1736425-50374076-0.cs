            private void button1_Click(object sender, EventArgs e)
        {
            TextEdit textEdit = new TextEdit();
            textEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            XtraInputBoxArgs args = new XtraInputBoxArgs();
            args.Caption = "Quantité";
            args.Prompt = "Entrez la quantité";
            args.DefaultButtonIndex = 0;
            args.DefaultResponse = "Test"; 
            args.Editor = textEdit;
            var result =  XtraInputBox.Show(args);
            if (result != null)
                MessageBox.Show("Ok button pressed");
            else
                MessageBox.Show("Cancel button pressed");
        }
