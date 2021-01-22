    public class ResourceLabel
        : Label
    {
        private string mResourceName;
        public string ResourceName
        {
            get { return mResourceName; }
            set
            {
                mResourceName = value;
                if (!string.IsNullOrEmpty(mResourceName))
                    base.Text = Properties.Resources.ResourceManager.GetString(mResourceName);
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get { return base.Text; }
            set 
            { 
                // Set is done by resource name.
            }
        }
    }
