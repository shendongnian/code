    if (activationids.Contains(gvselectActID))
    {
      // Goes here if condition is true
      activateInsert.Visible = true;
      activateUpdate.Visible = false;
      deactivate.Visible = true;
    }
    else
    {
      // Goes here if condition is false
      activateInsert.Visible = false;
      activateUpdate.Visible = true;
      deactivate.Visible = false;
    }
