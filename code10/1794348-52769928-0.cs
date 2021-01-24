    bool EndMeeting(ConversationWindow window)
    {
        var conversationWindowElement = AutomationElement.FromHandle(window.InnerObject.Handle);
        if (conversationWindowElement == null)
        {
            return false;
        }
    
        AutomationElement moreOptionsMenuItem;
        if (GetAutomationElement(conversationWindowElement, out moreOptionsMenuItem, "More options", ControlType.MenuItem))
        {
            (moreOptionsMenuItem.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern).Expand();
        }
        else if (GetAutomationElement(conversationWindowElement, out moreOptionsMenuItem, "More options", ControlType.Button))
        {
            // in the Office 365 version of lync client, the more options menu item is actually a button
            (moreOptionsMenuItem.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern).Invoke();
        }
        else
        {
            // didn't find it.
            return false;
        }
    
        AutomationElement menuOptionAction;
        if (!GetAutomationElement(moreOptionsMenuItem, out menuOptionAction, "End Meeting", ControlType.MenuItem))
        {
            return false;
        }
    
        (menuOptionAction.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern).Invoke();
        return true;
    }
    
    private static bool GetAutomationElement(AutomationElement rootElement, out AutomationElement resultElement, string name, ControlType expectedControlType)
    {
        Condition propCondition = new PropertyCondition(AutomationElement.NameProperty, name, PropertyConditionFlags.IgnoreCase);
        resultElement = rootElement.FindFirst(TreeScope.Subtree, propCondition);
        if (resultElement == null)
        {
            return false;
        }
    
        var controlTypeId = resultElement.GetCurrentPropertyValue(AutomationElement.ControlTypeProperty) as ControlType;
        if (!Equals(controlTypeId, expectedControlType))
        {
            return false;
        }
    
        return true;
    }
