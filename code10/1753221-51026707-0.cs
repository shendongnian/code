          Do Something like this. Just a quick written code. Might be syntax errors.
          
          DynamicTextBoxCreation.cs    
          public class DynamicTextBoxCreation
            {
            	public List<string> textBoxList;
            	
            	public ActionResult DynamicTextBox()
            	{
            	   /* Fill your dynamic list here from DB or from any other logic */
            	   return textBoxList;
            	}
            }
            
            DynamicTextBox.cshtml            
            @model DynamicTextBoxCreation;
            @code{
              var i = 1;
            }
            
            foreach(var tbItem in textBoxList)
            {
            	@Html.TextBox(' + tbItem + i + ', "", new {@class = "css-class", @onclick = "alert('demo');"});
            	i += 1;
            }
