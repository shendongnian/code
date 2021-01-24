    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    using System.Text;
    using System.Threading.Tasks;
    namespace PowershellCallTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                AdduserNotExpire(fNm: "first", lNm: null, uNm: "username", pWd: "myPass", gpUser: "myGroup");
            }
            private static void AdduserNotExpire(string fNm, string lNm, string uNm, string pWd, string gpUser)
            {
                RunspaceConfiguration runspaceConfiguration = RunspaceConfiguration.Create();
                Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration);
                runspace.Open();
                RunspaceInvoke scriptInvoker = new RunspaceInvoke(runspace);
                Pipeline pipeline = runspace.CreatePipeline();
                string scriptfile = @"C:\temp\addusernotexpire.ps1";
                Command myCommand = new Command(scriptfile);
                CommandParameter p1 = new CommandParameter("fname", fNm);
                CommandParameter p2 = new CommandParameter("lname", lNm);
                CommandParameter p3 = new CommandParameter("uname", uNm);
                CommandParameter p4 = new CommandParameter("pWd", pWd);
                CommandParameter p5 = new CommandParameter("grpUser", gpUser);
                myCommand.Parameters.Add(p1);
                myCommand.Parameters.Add(p2);
                myCommand.Parameters.Add(p3);
                myCommand.Parameters.Add(p4);
                myCommand.Parameters.Add(p5);
                pipeline.Commands.Add(myCommand);
                // invoke execution on the pipeline (ignore output)
                pipeline.Invoke();
            }
        }
    }
