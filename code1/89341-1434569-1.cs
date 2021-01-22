    if(settingsForm == null){
       settingsForm = new MaForm();
       settingsForm.show();
    }
    while (settingsForm != null && settingsForm.Visible)
    {
        System.Windows.Forms.Application.DoEvents();
    }
