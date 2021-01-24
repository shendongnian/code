    public static class MachineFactory
    {
         // this is assuming you are reading the machine name from AppConfig
         private static Lazy<string> _machineName = new Lazy<string>(() => ConfigurationManager.AppSettings["TargetMachine"]);
    
         public IMachine GetMachine()
         {
              switch(_machineName.Value)
              {
                   case "MachineA":
                        return new MachineA();                    
                   case "MachineB":
                        return new MachineB();
                   case "MachineC":
                        return new MachineC();
                   case "MachineD":
                        return new MachineD();
        
              }
         }
    }
