    public partial class DetailView : UserControl
    {
        public DetailView()
        {
            InitializeComponent();
            Mediator.PersonChangedDel += DetailView_PersonChanged;
        }
        void DetailView_PersonChanged(Person p)
        {
            BindData(p);
        }
        public void BindData(Person p)
        {
            lblPersonHairColor.Text = p.HairColor;
            lblPersonId.Text = p.IdPerson.ToString();
            lblPersonName.Text = p.Name;
            lblPersonNickName.Text = p.NickName;
        }
    }
