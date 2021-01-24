    var policies = (from pol in _context.Policy
                            join us in _context.User
                            on pol.userId equals us.FirebaseUID into policies
                            select new ExampleRes
                            {
                                userId = us.userId,
                                fuid = us.FirebaseUID,
                                policy = (from p in policies
                                          select new ExampleRes.PoliciesInfo
                                {
                                    policyId = p.policyId,
                                    policyType = p.policyType,
                                    policyPrice = p.price,
                                    coverageType = p.coverageType
                                }).ToList()
                            }).ToList();
