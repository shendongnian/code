    public void ProjectFinishedGenerating(Project project)
    {
      foreach (Configuration config in project.ConfigurationManager)
      {
        config.Properties.Item("StartAction").Value = 1; //Launch external program
        config.Properties.Item("StartProgram").Value = <pathToYourEXE>;
        config.Properties.Item("StartArguments").Value = <argumentsToYourExe>;
      }
    }
