    public KfxReturnValue RunUI()
    {
        using(FrmSetup frmSetup = new FrmSetup())  
        {
            try
            {
                if (frmSetup.ShowSetupForm(ref setupData) == DialogResult.OK)
                {
                    setupData.Apply(); // save the data which got setup in the form
                }
                return KfxReturnValue.KFX_REL_SUCCESS;
            }
            catch (Exception e)
            {
                // Log the exception
                return KfxReturnValue.KFX_REL_ERROR;
            }
        }
    }
