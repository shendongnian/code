     public static class Utilities
    {
        public enum DropDownListSelectionType
        {
            ByValue,
            ByText
        }
        public static void SelectItem(this  System.Web.UI.WebControls.DropDownList drp, string selectedValue, DropDownListSelectionType type)
        {
            drp.ClearSelection();
            System.Web.UI.WebControls.ListItem li;
            if (type == DropDownListSelectionType.ByValue)
                li = drp.Items.FindByValue(selectedValue.Trim());
            else
                li = drp.Items.FindByText(selectedValue.Trim());
            if (li != null)
                li.Selected = true;
        }}
