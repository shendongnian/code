        private static string Classifier(string inputDescription)
        {
            var classified = new Dictionary<string, string>
            {
                { "D/C FROM", "INCOME" },
                { "CREDIT ATM", "INCOME" },
                { "INTEREST", "INCOME" },
                { "EFTPOS", "EXPENSE" },
                { "DEBIT DEBIT", "EXPENSE" },
                { "CC DEBIT", "EXPENSE" },
                { "PAYMENT RECEIVED", "TRANSFER" },
                { "PAYMENT - THANK YOU", "TRANSFER" },
                { "IRD", "TAX" },
                { "I.R.D", "TAX" }
            };
            try
            {
                foreach (var kvp in classified)
                    if (inputDescription.StartsWith(kvp.Key))
                        return kvp.Value;
                return "OTHER";
            }
            catch
            {
                return "OTHER";
            }
        }
