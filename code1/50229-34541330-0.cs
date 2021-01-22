    foreach(Form frm in Application.OpenForms.Cast<Form>().ToList())
            {
                frm.Close();
            }
    System.Diagnostics.Process.Start(Application.ExecutablePath);
