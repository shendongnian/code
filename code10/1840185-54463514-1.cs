    private void OpenForm(object sender, ItemClickEventArgs e)
    {
        MyForm testForm = new MyForm();
        ...
        testForm.Enabled = true;
        testForm.FormClosed += (s, a) => {
          var dialogOk = testForm.DialogOK;
          if(dialogOk)
          {
             //do some stuff 1
          }
        };
        testForm.Show(this);
    }
