    namespace WpfApplication2
    {
        /// <summary>
        /// Interaction logic for View.xaml
        /// </summary>
        public partial class View : UserControl
        {
            public override void OnApplyTemplate()
            {
                MessageBox.Show(this.GetType().ToString());
                base.OnApplyTemplate();
            }
        }
    }
