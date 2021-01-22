    class WithLocale : IDisposable {
        Locale old;
        public WithLocale(Locale x) { old = ThirdParty.Locale; ThirdParty.Locale = x }
        public void Dispose() { ThirdParty.Locale = old }
    }
