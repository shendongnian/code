    public class CashPaymentService : IPaymentService
    {
        public Task<PaymentSettingsModel> GetPaymentSettings()
        {
            return Task.FromResult( new PaymentSettingsModel() );
        }
    }
