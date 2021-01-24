        class ATM
        {
            public int Denomination { get; set; }
            public int Inventory { get; set; }
            public ATM(int denom, int inven)
            {
                Denomination = denom;
                Inventory = inven;
            }
        }
        List<int> Bills = new List<int>();
        List<ATM> ATMs = new List<ATM>();
        private void OP2()
        {
            int[] picksToUse = { 100, 50, 20, 10, 5, 1 };
            foreach (int d in picksToUse )
            {
                ATM atm = new ATM(d, 10);
                ATMs.Add(atm);
            }
            //string sAmtRequested = Console.ReadLine();
            string sAmtRequested = textBox1.Text;
            if (int.TryParse(sAmtRequested, out int AmtRequested))
            {
                int RunningBalance = AmtRequested;
                do
                {
                    ATM BillReturn = GetBill(RunningBalance);
                    if (BillReturn is null)
                    {
                        MessageBox.Show("Cannot complete transaction");
                        return;
                    }
                    RunningBalance -= BillReturn.Denomination;
                } while (RunningBalance > 0);
            }
            else
            {
                MessageBox.Show("Non-numeric request.");
                return;
            }
            foreach (int bill in Bills)
                Debug.Print(bill.ToString());
            Debug.Print("Remaining Inventory");
            foreach (ATM atm in ATMs)
                Debug.Print($"For Denomination {atm.Denomination} there are {atm.Inventory} bills remaining");
        }
        private ATM GetBill(int RequestBalance)
        {
            var FilteredATMs = from atm in ATMs
                               where atm.Inventory > 0
                               orderby atm.Denomination descending
                               select atm;
                               
            foreach (ATM bill in FilteredATMs)
            {
                if (RequestBalance >= bill.Denomination )
                {
                    bill.Inventory -= 1;
                    Bills.Add(bill.Denomination);
                    return bill;
                }
            }
            return null;
        }
