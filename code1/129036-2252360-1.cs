    public class FrozenBaseForm : BaseForm
    {
        new public SizeF ClientSize
        {
            get { return base.ClientSize; }
            set { }
        }
    }
