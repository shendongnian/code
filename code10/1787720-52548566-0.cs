    this.AssociatedObject.CellRenderers.Remove("Template");  
    this.AssociatedObject.CellRenderers.Add("Template", new CustomGridCellTemplateRenderer());  
      
    public class CustomGridCellTemplateRenderer : GridCellTemplateRenderer  
    {  
         protected override void SetFocus(FrameworkElement uiElement, bool needToFocus)  
         {  
              base.SetFocus(uiElement, needToFocus);  
              var focusedElement = FocusManagerHelper.GetFocusedUIElement(CurrentCellRendererElement);  
              TextBox textBox = focusedElement as TextBox;  
              if(textBox == null)  
              {  
                  var comboBox = focusedElement as ComboBox;  
                  if(comboBox != null && comboBox.IsEditable)  
                  {  
                      textBox = (TextBox)GridUtil.FindDescendantChildByType(comboBox, typeof(TextBox));  
                  }  
              }  
              if (textBox != null)  
              {  
                  if (PreviewInputText == null)  
                  {  
                      var index = textBox.Text.Length;  
                      textBox.Select(index + 1, 0);  
                      return;  
                  }  
                  textBox.Text = PreviewInputText;  
                  var caretIndex = (textBox.Text).IndexOf(PreviewInputText.ToString());  
                  textBox.Select(caretIndex + 1, 0);  
                  PreviewInputText = null;  
              }  
         }  
    }  
