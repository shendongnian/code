        /// <summary>
        /// Selects the item in the list control that contains the specified text, if it exists.
        /// </summary>
        /// <param name="dropDownList"></param>
        /// <param name="selectedText">The text of the item in the list control to select</param>
        /// <returns>Returns true if the value exists in the list control, false otherwise</returns>
        public static Boolean SetSelectedText(this DropDownList dropDownList, String selectedText)
        {
            ListItem selectedListItem = dropDownList.Items.FindByText(selectedText);
            if (selectedListItem != null)
            {
                selectedListItem.Selected = true;
                return true;
            }
            else
                return false;
        }
