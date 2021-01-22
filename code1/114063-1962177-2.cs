    if (HtmlNode.IsCDataElement(CurrentNodeName()))
    {
       _state = ParseState.PcData;
       return true;
    }
    // new code start
    if ( !AllowedTags.Contains(_currentnode.Name) )
    {
        close = true;
    }
    // new code end
