    public bool CheckIISRunning()
      {
         ServiceController controller = new ServiceController("W3SVC");
         return controller.Status == ServiceControllerStatus.Running;
      }
