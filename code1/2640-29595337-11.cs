    public partial class DetailView : UserControl
    {
        public DetailView()
        {
            InitializeComponent();
            Mediator.GetInstance().PersonChanged += DetailView_PersonChanged;
        }
        void DetailView_PersonChanged(object sender, PersonChangedEventArgs e)
        {
            BindData(e.Person);
        }
        public void BindData(Person p)
        {
            lblPersonHairColor.Text = p.HairColor;
            lblPersonId.Text = p.IdPerson.ToString();
            lblPersonName.Text = p.Name;
            lblPersonNickName.Text = p.NickName;
        }
    }
