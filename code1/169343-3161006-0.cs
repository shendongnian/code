    Mtb.Application MtbApp = null;
    Mtb.Project MtbProj = null;
    Mtb.UserInterface MtbUI = null;
    
    MtbApp = new Mtb.Application();
    MtbProj = MtbApp.ActiveProject;
    MtbUI = MtbApp.UserInterface;
    
    MtbUI.Visible = true;
    MtbProj.ExecuteCommand("RANDOM 30 C1-C2", Type.Missing); //with C# optional params required
    MtbApp.Quit();
    
    Marshal.ReleaseComObject(MtbUI); MtbUI = null;
    Marshal.ReleaseComObject(MtbProj); MtbProj = null;
    Marshal.ReleaseComObject(MtbApp); MtbApp = null;
