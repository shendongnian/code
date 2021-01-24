    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;
    
    namespace WpfApp2
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            readonly Random _random;
    
            public MainWindow()
            {
                InitializeComponent();
    
                _random = new Random();
    
                DataContext = this;
    
                Transactions = new ObservableCollection<Transaction>();
                // add some transactions to the collection to get things started
                AddTransaction(new Transaction()
                    {
                        Date = DateTime.Now.Subtract(TimeSpan.FromDays(5)),
                        Amount = -35.66M
                    });
    
                AddTransaction(new Transaction()
                    {
                        Date = DateTime.Now.Subtract(TimeSpan.FromDays(4)),
                        Amount = -22.00M
                    });
    
                AddTransaction(new Transaction()
                    {
                        Date = DateTime.Now.Subtract(TimeSpan.FromDays(3)),
                        Amount = -10.10M
                    });
            }
    
            /// <summary>
            /// All transactions are added to the collection through this method so that the running balance
            /// can be calculated based on the previous transaction
            /// </summary>
            /// <param name="transaction"></param>
            void AddTransaction(Transaction transaction)
            {
                //find the preceding transaction
                var precedingTransaction = Transactions.Where(t => t.Date &lt; transaction.Date)
                    .OrderByDescending(t => t.Date)
                    .FirstOrDefault();
    
                if(precedingTransaction == null)
                {
                    //This is the earliest transaction so calc based on starting balance
                    transaction.RunningBalance = StartingBalance + transaction.Amount;
                } else
                {
                    //this is not the earliest transaction so calc based on previous
                    transaction.RunningBalance = precedingTransaction.RunningBalance + transaction.Amount;
                }
    
                //Add the transactions to the collection with the calculated balance
                Transactions.Add(transaction);
            }
    
            void BtnAddItem_Click(object sender, RoutedEventArgs e)
            {
                AddTransaction(new Transaction()
                    {
                        Date = DateTime.Now,
                        //generate a random dollar amount
                        Amount = (decimal)-Math.Round(_random.Next(1, 100) + _random.NextDouble(), 2)
                    });
            }
            
            public decimal StartingBalance => 345.00M;
    
            public ObservableCollection<Transaction> Transactions { get; set; }
        }
    
        public class Transaction
        {
            public decimal Amount { get; set; }
    
            public DateTime Date { get; set; }
    
            public decimal RunningBalance { get; set; }
        }
    }
    
