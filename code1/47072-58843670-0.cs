    public partial class MyForm : Form
    {
    ...
        protected override void SetVisibleCore(bool value)
        {
	        if (value && !IsHandleCreated && !ContinueLoadingForm())
	        {
		        base.SetVisibleCore(false);
		        this.Close();
		        return;
	        }
	        base.SetVisibleCore(value);
        }
    }
