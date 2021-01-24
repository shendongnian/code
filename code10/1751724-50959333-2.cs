    var policies = (from us in _context.User
                    select new ExampleRes
                    {
                        userId = us.userId,
                        fuid = us.FirebaseUID,
                        policy = (
                            from pol in _context.Policy
                            where pol.userId == us.FirebaseUID
                            select new ExampleRes.PoliciesInfo
                            {
                                policyId = pol.policyId,
                                policyType = pol.policyType,
                                policyPrice = pol.price,
                                coverageType = pol.coverageType
                            }
                        ).ToList()
                    }).Where(u => u.policy.Count > 0).ToList();
