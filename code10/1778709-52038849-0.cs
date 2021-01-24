    interop.CimAppAccess.AppAccess AppAcc = new interop.CimAppAccess.AppAccess();
    interop.CimatronE.IApplication CimApp = /*(interop.CimatronE.IApplication)*/AppAcc.GetApplication();
    interop.CimatronE.IPdm pdm = CimApp.GetPdm();
    var RelatedDocuments = pdm.GetRelatedDocuments("path");
    Console.WriteLine(RelatedDocuments);
