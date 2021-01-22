    private EntitySet<TransactionType> _TransactionTypes;
        [Association(Name="Custtran_TranType", Storage = "_TransactionTypes", IsForeignKey=true, ThisKey="TranType", OtherKey = "TranType")]
        public EntitySet<TransactionType> TransactionTypes
        {
            get { return this._TransactionTypes; }
            set { this._TransactionTypes.Assign(value); }
        }
