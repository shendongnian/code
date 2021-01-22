    var vsBehaviour = channelFactory.Endpoint.EndpointBehaviors
        .FirstOrDefault(i =>
            i.GetType().Namespace == "Microsoft.VisualStudio.Diagnostics.ServiceModelSink");
    if (vsBehaviour != null)
    {
        channelFactory.Endpoint.Behaviors.Remove(vsBehaviour);
    }
