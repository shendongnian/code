    private asyc void OpenForm(object sender, ItemClickEventArgs e) {
        var source = new TaskCompletionSource<DialogResult>();
    
        EventHandler handler = null;
        handler = (s, args) => { 
            var  form = (MyForm)s;
            form.FormClosed -= handler;
            source.SetResult(form.DialogResult);
        }
        var testForm = new MyForm();
        testForm.FormClosed += handler; //subscribe
        //...
        testForm.Enabled = true;
        testForm.Show();
        var dialogOk = await source.Task;
        if(dialogOk == DialogResult.Ok) {
           //do some stuff 1
        }
    }
