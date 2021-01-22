    if (ApplicationFormStatus.CheckIfFormIsOpen("FormName")) 
    {
    // It means it exists, so close the form
    }
    
     public bool CheckIfFormIsOpen(string formname)
            {
              
                //FormCollection fc = Application.OpenForms;
                //foreach (Form frm in fc)
                //{
                //    if (frm.Name == formname)
                //    {
                //        return true;
                //    }
                //}
                //return false;
    
                bool formOpen= Application.OpenForms.Cast<Form>().Any(form => form.Name == formname);
    
                return formOpen;
            }
