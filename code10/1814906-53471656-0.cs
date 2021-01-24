    public class TransactionModalVM
    {
        public  TransactionModalVM(IReadOnlyList<IComboBoxItem> categoryList)
        {
            CategoryList = categoryList;
        }
    
    public IReadOnlyList<IComboBoxItem> CategoryList { get; set; }
    }
