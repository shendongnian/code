    public class InterceptorForm : Form
    {
        protected override void OnLoad(EventArgs e)
        {
            ...
            if (this.GetType() != typeof(UpdateHint) && MainWindow.updateHint != null)
            {
                Log.t("Setting owner on update hint during onload: " + this.GetType());
                MainWindow.updateHint.Owner = this;
            }
            base.OnLoad(e);
        }
