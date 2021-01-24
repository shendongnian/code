    public bool CheckIfFormIsAlreadyOpen(string className)
    {
        bool Result = false;
        className = className.ToUpper();
        int i = 0;
        while ((i < Application.OpenForms.Count) && (Application.OpenForms[i].Name.ToUpper() != className))
        {
            i++;
        }
        if (i < Application.OpenForms.Count)
        {
            Application.OpenForms[i].Show();
            Application.OpenForms[i].BringToFront();
            if (Application.OpenForms[i].WindowState == FormWindowState.Minimized)
            {
               ShowWindowAsync(Application.OpenForms[i].Handle, 9); // 9 = SW_RESTORE
            }
            Result = true;
        }
        return Result;
    }
