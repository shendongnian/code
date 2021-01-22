    public class LocalizedButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            this.Text = MyGlobalResources.GetItem(this.Tag.ToString());
        }
    }
