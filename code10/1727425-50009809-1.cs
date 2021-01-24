    public static class PaymentHelpers {
        public static Dictionary<int, PaymentClass> PaymentMap;
        public static void SetupPaymentMap(PaymentClass[] db) {
            PaymentMap = db.ToDictionary(p => p.ID);
        }
        public static PaymentClass PaymentForID(int anID) => PaymentMap.TryGetValue(anID, out var p) ? p : null;
    
        public static IEnumerable<PaymentClass> Parents(PaymentClass[] db, int id) {
            var p = PaymentForID(id);
            while (p.ParentPaymentId.HasValue) {
                p = PaymentForID(p.ParentPaymentId.Value);
                yield return p;
            }
        }
    }
