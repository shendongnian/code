    public sealed partial class EditRules
    {
    private List<object> _editRulesViewModel = new List<object>();
    public EditRules()
    {
        DataContext = this;
        InitializeComponent();
    }
    //Add nullchecking, etc.
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        _editRulesViewModel.Clear();
        foreach (item in ((EditRulesViewModel)e.Parameter)RuleSet.RuleMainSystems)
        {        
            _editRulesViewModel.Add(item);
        }
    }
    }
    <ComboBox x:Name="MainSystemComboBox" DisplayMemberPath="Name" ItemsSource="_editRulesViewModel" />
