    public class LabelChanger
    {
      public static void SetLabelText(Form form, string labelID, string labelText)
      {
        Label lbl = form.Controls["labelID"] as Label;
        if(lbl != null)
          lbl.Text = labelText;
      }
    }
