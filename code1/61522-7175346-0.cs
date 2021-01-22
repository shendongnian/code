    public List<State> GetcountryCodeStates(List<string> countryCodes)
    {
        List<State> states = new List<State>();
        states = (from a in _objdatasources.StateList.AsEnumerable()
        where countryCodes.Any(c => c.Contains(a.CountryCode))
        select a).ToList();
        return states;
    }
