    public class ResourceContentTextBlock : TextBlock
    {
        public string ResourceName 
        {
            set
            {
                this.Text = Properties.Resources.ResourceManager.GetString("String1");
            }
        }
    }
