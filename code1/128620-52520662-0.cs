    public partial class ProjectInstaller : Installer
    {
        protected override void OnBeforeInstall(IDictionary savedState)
        {
            SetServiceName();
            base.OnBeforeInstall(savedState);
        }
        protected override void OnBeforeUninstall(IDictionary savedState)
        {
            SetServiceName();
            base.OnBeforeUninstall(savedState);
        }
        private string AppendParameter(string path, char parameter, string value)
        {
            if (!path.StartsWith("\""))
                path = $"\"{path}\"";
            if (value.Contains(" "))
                value = $"\"{value}\"";
            return $"{path} -{parameter}{value}";
        }
        private void SetServiceName()
        {
            if (Context.Parameters.ContainsKey("ServiceName"))
                serviceInstaller.ServiceName = Context.Parameters["ServiceName"];
            if (Context.Parameters.ContainsKey("DisplayName"))
                serviceInstaller.DisplayName = Context.Parameters["DisplayName"];
            Context.Parameters["assemblypath"] = AppendParameter(Context.Parameters["assemblypath"], 's', serviceInstaller.ServiceName);
        }
    }
