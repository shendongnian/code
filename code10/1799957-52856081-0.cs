    public class Combo : ComboBox
    {
         protected override void OnClick(EventArgs e)
         {
             if (!DroppedDown) base.OnClick(e);
         }           
    }
