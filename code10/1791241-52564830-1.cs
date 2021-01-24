      var observable = Observable.FromEvent<_IZKEMEvents_OnAttTransactionExEventHandler, MyArgs>(
             converter => new _IZKEMEvents_OnAttTransactionExEventHandler(
                             (enrollNumber, isInValid, attState, verifyMethod, year, month, day, hour, minute, second, workCode)
                             => converter(new MyArgs
                             {
                                 EnrollNumber = enrollNumber,
                                 IsInValid = isInValid,
                                 AttState = attState,
                                 VerifyMethod = verifyMethod,
                                 Day=day,
                                 Hour=hour,
                                 Minute=minute,
                                 Month=month,
                                 Second=second,
                                 WorkCode=workCode,
                                 Year=year
                             })
                     ),
             handler => axCZKEM.OnAttTransactionEx += handler,
             handler => axCZKEM.OnAttTransactionEx -= handler);
