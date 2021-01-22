    public control FIndControlEx(COntrolsCollection controls, string id)
    {
    
       foreeach(Control ctrl in controls)
       {
          if (ctrl.id == id)
             return ctrl;
          var result = FindCOntrolEx(ctrl.Controls, id);
          if (result != null)
            return result;
       }
    }
