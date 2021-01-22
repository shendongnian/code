    class TestLock
    {
        public static int balance { get; set; }
        public static readonly Object myLock = new Object();
        public void Withdraw(int amount)
        {
            if (balance <= 0)
                Console.WriteLine("Can't process your transaction, current balance is :  " + balance);
            // Try both locks to see what I mean
            //           lock (myLock)
            lock (this)
            {
                Random rand = new Random();
                if (balance >= amount)
                {
                    Console.WriteLine("Balance before Withdrawal :  " + balance);
                    Console.WriteLine("Withdraw        : -" + amount);
                    balance = balance - amount;
                    Console.WriteLine("Balance after Withdrawal  :  " + balance);
                }
                else
                {
                    Console.WriteLine("Can't process your transaction, current balance is :  " + balance + " and you tried to withdraw " + amount);
                }
            }
        }
        public void WithdrawAmount()
        {
            Random rand = new Random();
            Withdraw(rand.Next(1, 100) * 100);
        }
    }
