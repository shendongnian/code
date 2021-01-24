    using System.Diagnostics;
    public void Configure(DiagnosticListener diagnosticListener)
    {
        diagnosticListener.SubscribeWithAdapter(new RazorPerformanceDiagnosticListener());
    }
