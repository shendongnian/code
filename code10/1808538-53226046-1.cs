    public static bool CheckServicesFromServer(string pServicos)
            {
                ImpersonateUser Iu = new ImpersonateUser();
                ServiceController service = new ServiceController();
                List<string> Servicos = pServicos.Split(',').Select(p => p.Trim()).ToList();
    
                if (Config.BaseLogin == BasesSistema.QualityLogin)
                    service.MachineName = "quality";
                if (Config.BaseLogin == BasesSistema.TS02Login)
                    service.MachineName = "ts02";
                if (Config.BaseLogin == BasesSistema.TS03Login)
                    service.MachineName = "ts03";
                if (Config.BaseLogin == BasesSistema.LocalHost)
                    service.MachineName = Environment.MachineName;
    
                Iu.Impersonate(Config.Dominio, Config.LoginMaster, Config.SenhaMaster);
    
                try
                {
                    foreach (var item in Servicos)
                    {
                        service.ServiceName = item;
    
                        if ((service.Status.Equals(ServiceControllerStatus.Stopped)) || (service.Status.Equals(ServiceControllerStatus.StopPending)))
                        {
                            Flag = true;
                            File.AppendAllText(StatusLog.StatusLocation, "O servico " + service.ServiceName + " está parado. a Regra não será gerada. <br />");
                            throw new Exception();
                        }
    
                        if (service.Status.Equals(ServiceControllerStatus.Running))
                        {
                            File.AppendAllText(StatusLog.StatusLocation, "O serviço " + service.ServiceName + " está rodando perfeitamente. <br />");
                        }
                    }
                    Iu.Undo();
                }
    
                catch
                {
                    Iu.Undo();
                    Log.WriteErrorLog("Não é possível abrir o Gerenciador de Controle de Serviços no Computador '" + service.MachineName + "'. <br />");
                    return false;
                }
                return true;
            }
