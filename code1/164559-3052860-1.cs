    ServiceController _ServiceController = new ServiceController([NameService]);
    if (!_ServiceController.ServiceHandle.IsInvalid) 
    {
         _ServiceController.Stop();
         _ServiceController.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromMilliseconds(uConstante.CtTempoEsperaRespostaServico));
    }
