        public static void ActionSelectComboBoxItem(AutomationElement comboBoxElement, int indexToSelect){
            if(comboBoxElement == null)
                throw new Exception("Combo Box not found");
            //Get the all the list items in the ComboBox
            AutomationElementCollection comboboxItem = comboBoxElement.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem));
            //Expand the combobox
            ExpandCollapsePattern expandPattern = (ExpandCollapsePattern)comboBoxElement.GetCurrentPattern(ExpandCollapsePattern.Pattern);
            expandPattern.Expand();
            //Index to set in combo box
            AutomationElement itemToSelect = comboboxItem[indexToSelect];
            //Finding the pattern which need to select
            SelectionItemPattern selectPattern = (SelectionItemPattern)itemToSelect.GetCurrentPattern(SelectionItemPattern.Pattern);
            selectPattern.Select();
        }
