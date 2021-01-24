        get => this._depositAmount;
        set
        {
            if (this._depositAmount != value)
            {
                this._depositAmount = value;
                OnPropertyChanged(nameof(DepositAmount));
                OnPropertyChanged(nameof(BalanceAfterDeposit));
            }
        }
    }
