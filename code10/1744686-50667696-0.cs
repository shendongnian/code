    public partial class NutritionPlan : Page
    {
        public NutritionPlanVM ViewModel { get { return DataContext as NutritionPlanVM; } set { DataContext = value; } }
        public NutritionPlan(Object NPlan)
        {
            InitializeComponent();
            ViewModel = new NutritionPlanVM(NPlan);
        }
    }
