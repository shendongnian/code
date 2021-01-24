    private IMarkupConverter markupConverter;
    
    public PersonalDetailsEditPage()
            {
                InitializeComponent();
                Current = this;
                markupConverter = new MarkupConverter.MarkupConverter();
                DataContext = this;
            }
    
     public void Populate_Data(UserModel userModel)
            {
                doc = AddressTextBox.Document;
                htmlStr_address = markupConverter.ConvertRtfToHtml(FlowDocument_GetText(doc));
            }
