    namespace SilverlightClassLibrary1
    {
        public class MyButton: Button
        {
            public string BackgroundColor { get; set; }
            public override void OnApplyTemplate()
            {
                base.OnApplyTemplate();
                if (BackgroundColor != null)
                {
                    Rectangle r = this.GetTemplateChild("BackgroundGradient") as Rectangle;
                    if (r != null)
                    {
                        r.Fill = new SolidColorBrush(Color.FromArgb(255, 
                            Convert.ToByte(BackgroundColor.Substring(1,2),16),
                            Convert.ToByte(BackgroundColor.Substring(3,2),16),
                            Convert.ToByte(BackgroundColor.Substring(5,2),16)));
                    }
                }
            }
        }
    }
