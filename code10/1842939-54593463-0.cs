    private void radCheckedDropDownList1_LostFocus(object sender, EventArgs e)
    {
         string delimiter = this.radCheckedDropDownList1.CheckedDropDownListElement.AutoCompleteEditableAreaElement.AutoCompleteTextBox.Delimiter;
         StringBuilder sb = new StringBuilder();
         foreach (RadListDataItem item in this.radCheckedDropDownList1.CheckedItems)
         {
             sb.Append(item.Text + delimiter);
         }
         this.radCheckedDropDownList1.Text = sb.ToString();                              
    }
