    //[QUICK CODE] FOR THE IMPATIENT
    using System;
    using System.Collections.Generic;
    using System.Text;
    // ADD "using System.ServiceProcess;" after you add the 
    // Reference to the System.ServiceProcess in the solution Explorer
    using System.ServiceProcess;
    namespace Using_ServiceController{
        class Program{
            static void Main(string[] args){
                ServiceController myService = new ServiceController();
                myService.ServiceName = "ImapiService";
                string svcStatus = myService.Status.ToString();
                    if (svcStatus == "Running"){
                        myService.Stop();
                    }else if(svcStatus == "Stopped"){
                        myService.Start();
                    }else{
                        myService.Stop();
                    }
            }
        }
    }
