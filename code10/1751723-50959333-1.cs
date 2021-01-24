    var policies = (from pol in _context.Policy
                    join us in _context.User
                    on pol.userId equals us.FirebaseUID
                    select new ExampleRes
                    {
                        userId = us.userId,
                        fuid = us.FirebaseUID,
                        policy = new List<ExampleRes.PoliciesInfo> {
                            new ExampleRes.PoliciesInfo
                            {
                                 policyId = pol.policyId,
                                 policyType = pol.policyType,
                                 policyPrice = pol.price,
                                 coverageType = pol.coverageType
                            }
                        }
                    }).ToList();
