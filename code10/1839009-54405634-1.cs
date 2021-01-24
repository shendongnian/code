    if (!formattingEnabled) {
 
        // Microsoft gave his blessing to this RTM breaking change
        if (item == null) {
            return String.Empty;
        }
 
        item = FilterItemOnProperty(item, displayMember.BindingField);
        return (item != null) ? Convert.ToString(item, CultureInfo.CurrentCulture) : "";
    }
