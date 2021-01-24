        public class Expense_ExpenseType
        {
           public int ExpenseId { get; set; }
           public Expense Expense { get; set; }
           public int ExpenseTypeId { get; set; }
           public ExpenseType ExpenseType { get; set; }
        }
