    delegate void CustomSwitchDestination();
    List<KeyValuePair<string, CustomSwitchDestination>> customSwitchList;
    CustomSwitchDestination defaultSwitchDestination = new CustomSwitchDestination(NoMatchFound);
    void CustomSwitch(string value)
    {
        foreach (var switchOption in customSwitchList)
            if (switchOption.Key.Equals(value, StringComparison.InvariantCultureIgnoreCase))
            {
                switchOption.Value.Invoke();
                return;
            }
        defaultSwitchDestination.Invoke();
    }
