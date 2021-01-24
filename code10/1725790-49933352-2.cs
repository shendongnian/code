    if (Session["IdUsuario"] == null)
    {
        return RedirectToAction("Index", "Home"); // replacement of Response.Redirect to root page
    }
    else
    {
        if ((bool)Session["Temporal"] == true)
        {
            // use RedirectToAction instead of Response.Redirect
            return RedirectToAction("ContrasenaTemporal", "Login"); 
        }
        else
        { 
            // return something else
        }
    }
