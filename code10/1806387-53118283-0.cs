    /// <summary>
    /// Объект данных запроса уведомления о поступившем платеже
    /// </summary>
    public class IncomingPayment
    {
        /// <summary>
        /// Сумма поступившего платежа
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// Сумма поступившего платежа в строковом формате
        /// </summary>
        private string _amountAsString;
        /// <summary>
        /// Обертка суммы поступившего платежа в строковом формате
        /// </summary>
        [Required]
        [BindProperty(Name = "amount", SupportsGet = false)]
        public string AmountAsString
        {
            get => _amountAsString;
            set
            {
                _amountAsString = value;
                if (!decimal.TryParse(_amountAsString.Replace('.', Program.PointChar), out var doubleAmount)) return;
                Amount = doubleAmount;
            }
        }
    }
