    _host = new ServiceHost(...);
    for (int i = 0; i < _host.Description.Behaviors.Count; i++)
    {
        if (_host.Description.Behaviors[i] is AspNetCompatibilityRequirementsAttribute)
        {
          _host.Description.Behaviors.RemoveAt(i);
          break;
        }
    }
    _host.Description.Behaviors.Add(new AspNetCompatibilityRequirementsAttribute { RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed });
    _host.Open();
