    using System;
    namespace ReportTester {
       class TestProperties
       {
            internal String ReportServerUrl { get; private set; }
            internal TestProperties()
            {
                ReportServerUrl = "http://myhost/ReportServer/ReportExecution2005.asmx?wsdl";
            }
       }
    }
