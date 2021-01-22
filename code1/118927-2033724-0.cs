    public class CheckedListBoxEx : CheckedListBox
    {
        protected override void OnItemCheck(ItemCheckEventArgs ice)
        {
            ice.NewValue = ice.CurrentValue;
        }
    }
