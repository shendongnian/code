    private void OpenForm(object sender, ItemClickEventArgs e)
    {
        MyForm testForm = new MyForm();
        ...
        testForm.Enabled = true;
        testForm.FormClosed += (sender, args) => {
          var dialogOk = testForm.DialogOK;
          if(dialogOk)
          {
             //do some stuff 1
          }
        };
        testForm.Show(this);
    }
