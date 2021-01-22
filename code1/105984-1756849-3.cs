    public interface IMainConfigInterop
    {
      void AddConfigurationCheckBox(ConfigurationText text);
      void AddConfigurationRadioButton(ConfigurationText text);
      void AddConfigurationSpinEdit(Confguration text, int minValue, int maxValue);
    }
    public interface IConfigurable
    {
      void LoadConfig(string configFile);
    
      void PrepareConfigWindow(IMainConfigInterop configInterop);
    }
