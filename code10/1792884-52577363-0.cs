    using log4net;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            private static readonly ILog Logger = LogManager.GetLogger(typeof(Form1).FullName);
            public PersonViewPresenter Presenter { get; private set; }
            public Form1()
            {
                InitializeComponent();
                Presenter = new PersonViewPresenter();
                Presenter.PropertyChanged += Presenter_PropertyChanged;
                AddBindings();
            }
    
            private void Presenter_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                Logger.Info($"Property changed {e.PropertyName}");
            }
    
            private void AddBindings()
            {
                _firstnameTextbox.DataBindings.Add(new Binding(nameof(_firstnameTextbox.Text), Presenter, nameof(Presenter.FirstName), false, DataSourceUpdateMode.OnValidation));
                _lastnameTextBox.DataBindings.Add(new Binding(nameof(_lastnameTextBox.Text), Presenter, nameof(Presenter.LastName), false, DataSourceUpdateMode.OnValidation));
            }
        }
    }
