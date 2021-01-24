    public class ActvityTagsTelemetryInitializer : ITelemetryInitializer
    {
        public void Initialize(ITelemetry telemetry)
        {
            Activity current = Activity.Current;
    
            if (current == null)
            {
                current = (Activity)HttpContext.Current?.Items["__AspnetActivity__"];
            }
    
            while (current != null)
            {
                foreach (var tag in current.Tags)
                {
                    if (!telemetry.Context.Properties.ContainsKey(tag.Key))
                    {
                        telemetry.Context.Properties.Add(tag.Key, tag.Value);
                    }
                }
    
                current = current.Parent;
            }
        }
    }
