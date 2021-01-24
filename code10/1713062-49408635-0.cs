    Task("RunTests")
        .IsDependentOn("Build")
        .Does(() =>
    {
        SpecFlowTestExecutionReport(tool => {
        tool.NUnit3("./SampleProject/bin/Release/SampleProject.dll",
            new NUnit3Settings {
                Results = new List<NUnit3Result> {
                    new NUnit3Result {
                        FileName = "testresults.xml",
                        Format = "nunit2"
                    }
                },
                Labels = NUnit3Labels.All,
                OutputFile = "testoutput.txt"
            });
        }, project,
        new SpecFlowTestExecutionReportSettings {
            Out = "report.html"
        });
    });
