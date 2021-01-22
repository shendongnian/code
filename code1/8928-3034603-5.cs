    public sealed class CustomerComboBox : ComboBox, ICustomerComboBox {
        private readonly CustomerComboBoxPresenter presenter;
        public CustomerComboBox() {
            presenter = new CustomerComboBoxPresenter(this);
        }
        protected override void OnLoad() {
            if (!Page.IsPostBack) presenter.HandleFirstLoad();
        }
        // Primary interface used by web page developers
        public Guid ClientId {
            get { return new Guid(SelectedItem.Value); }
            set { SelectedItem.Value = value.ToString(); }
        }
        // "Hidden" interface used by presenter
        IEnumerable<CustomerDto> ICustomerComboBox.DataSource { set; }
    }
