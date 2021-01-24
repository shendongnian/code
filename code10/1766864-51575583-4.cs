    foreach (CheckBox c in checkBoxlist)
    {
         If (c.IsChecked == true)
            {
            //Code when checkbox is checked
            var _tempTBL = (TextBlock) c.Content; //Get handle to TextBlock
            var foo = _tempTBL.Text; //Read TextBlock's text
            //foo is now a string of the checkbox's content
            }
    }
