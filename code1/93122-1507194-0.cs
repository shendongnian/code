    var mocks = new MockRepository();
    var printer = mocks.DynamicMock<IPrinter>();
    using (printer.Ordered())
    {
        printer.Expect(x => x.PrintComment());
        printer.Expect(x => x.PrintSpecial());
        printer.Expect(x => x.PrintComment());
    }
    printer.Replay();
    Script = new Script(printer);
    ... Execute Test...
    printer.VerifyAllExpectations();
