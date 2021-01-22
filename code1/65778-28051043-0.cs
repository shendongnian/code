    public class ImprovedMyTableAdapter : MyTableAdapter
    {
        public ImprovedMyTableAdapter()
            : base()
        {
            int parsedInt = int.MinValue;
            string appSettingValue = System.Configuration.ConfigurationManager.AppSettings["MyTableAdapter_CommandTimeout"];
            if (string.IsNullOrEmpty(appSettingValue))
                appSettingValue = System.Configuration.ConfigurationManager.AppSettings["CommandTimeout"];
            if (!string.IsNullOrEmpty(appSettingValue) && int.TryParse(appSettingValue, out parsedInt))
            {
                foreach (var command in this.CommandCollection)
                    command.CommandTimeout = parsedInt;
            }
        }
    }
