    var success = this.Client.MyServiceCall(
        new myObject
        {
            // Because WCF obliterates the enum, casting to byte for its respective ID is needed:
            AccrualRevenueRecognitionId = (byte)viewModel.QualityOfFinancials.AccrualRevenueRecognition,
            CashRevenueRecognitionId = (byte)viewModel.QualityOfFinancials.CashRevenueRecognition
        }
    );
