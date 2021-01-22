    _host = new ServiceHost(...);
    // Remove existing behavior as it is readOnly
    for (int i = 0; i < _host.Description.Behaviors.Count; i++)
    {
        if (_host.Description.Behaviors[i] is AspNetCompatibilityRequirementsAttribute)
        {
          _host.Description.Behaviors.RemoveAt(i);
          break;
        }
    }
    // Replace behavior with one that is configured the way you desire.
    _host.Description.Behaviors.Add(new AspNetCompatibilityRequirementsAttribute { RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed });
    _host.Open();
