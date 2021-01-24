    public interface ITransactionRepository<TCategory, TCustomerId, TProduct, TDepartment>
    {
        void SearchTransactionbyCategoryCustomerId(TCategory Category, TCustomerId CustomerId );
        void SearchTransactionbyProductDepartment(TProduct Product, TDepartment Department); 
        ......
    }
    public class TransactionRepository1: ITransactionRepository<string, int, char, long>
    {
        void SearchTransactionbyCategoryCustomerId(string Category, int CustomerId);
        void SearchTransactionbyProductDepartment(char Product, long Department); 
        ......
    }
    public class TransactionRepository2: ITransactionRepository<char, double, double, string>
    {
        void SearchTransactionbyCategoryCustomerId(char Category, double CustomerId);
        void SearchTransactionbyProductDepartment(double Product, string Department); 
        ......
    }
