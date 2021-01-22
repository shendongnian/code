    /* Add this reference */
    
    using System.Text.RegularExpressions;
    
    ---------------------------
    
    if (!string.IsNullOrWhiteSpace(txtEmail.Text))
    {
        Regex reg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        if (!reg.IsMatch(txtEmail.Text))
        {
            Mensaje += "* El email no es válido. \n\n";
            isValid = false;
        }
    }
