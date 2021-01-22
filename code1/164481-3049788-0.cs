    helper.Setup(c => c.GetPlanPeriods(It.IsAny<string>(),It.IsAny<List<PaymentPlanPeriod>>()))
                .Callback((string s, List<PaymentPlanPeriod> l)=>
                              {
                                  l.Add(new PaymentPlanPeriod(1000m, args.MinDate.ToString()));
                              });
