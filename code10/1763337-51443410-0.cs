    public class ViewModel : INotifyPropertyChanged
    {
    // Your class methods and properties
        public DelegateCommand<string> AddNewExpenseCategory
        {
           get
           {
                return new DelegateCommand<string>(Execute_AddNewExpenseCategory);
           }
        }
        public void Execute_AddNewExpenseCategory(string param)
        {
            expenseCategories.Add(new ExpenseCategory() { param });
            context.SaveChanges();
        }
