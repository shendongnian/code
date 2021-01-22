    // Hold a list of all the transistions we have done.  This will help us not have run them again If we already have.
    private static Dictionary<WorkItemType, List<Transition>> _allTransistions = new Dictionary<WorkItemType, List<Transition>>();
    /// <summary>
    /// Get the transitions for this <see cref="WorkItemType"/>
    /// </summary>
    /// <param name="workItemType"></param>
    /// <returns></returns>
    private static List<Transition> GetTransistions(this WorkItemType workItemType)
    {
        List<Transition> currentTransistions;
        
        // See if this WorkItemType has already had it's transistions figured out.
        _allTransistions.TryGetValue(workItemType, out currentTransistions);
        if (currentTransistions != null)
            return currentTransistions;
        
        // Get this worktype type as xml
		XmlDocument workItemTypeXml = workItemType.Export(false);
        // Create a dictionary to allow us to look up the "to" state using a "from" state.
        var newTransistions = new List<Transition>();
        // get the transistions node.
        XmlNodeList transitionsList = workItemTypeXml.GetElementsByTagName("TRANSITIONS");
        // As there is only one transistions item we can just get the first
        XmlNode transitions = transitionsList[0];
        // Iterate all the transitions
        foreach (XmlNode transition in transitions)
        {
            // save off the transistion 
            newTransistions.Add(new Transition
                                    {
                                        From = transition.Attributes["from"].Value,
                                        To = transition.Attributes["to"].Value
                                    });
        }
        // Save off this transition so we don't do it again if it is needed.
        _allTransistions.Add(workItemType, newTransistions);
        return newTransistions;
    }
    public class Transition
    {
        public string To { get; set; }
        public string From { get; set; }
    }
