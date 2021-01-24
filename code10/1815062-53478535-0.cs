      private async Task<IEnumerable<string>> Process(string command)
        {
            var output = new List<string>();
            using (var powerShell = System.Management.Automation.PowerShell.Create())
            {
                powerShell.AddScript(command);
                var outputCollection = new PSDataCollection<PSObject>();
                await Task.Factory.FromAsync(
                    powerShell.BeginInvoke<PSObject, PSObject>(null, outputCollection),
                    result =>
                    {
                        OnDeployEnd?.Invoke(this, EventArgs.Empty);
                        foreach (var data in outputCollection)
                        {
                            output.Add(data.ToString());
                        }
                    }
                );
                if (powerShell.HadErrors)
                {
                    var errorsReport = powerShell.Streams.Error.GetErrorsReport();
                    throw new Exception(errorsReport);
                }
            }
            return output;
        }
