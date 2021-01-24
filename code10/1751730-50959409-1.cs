    var policies = (from us in _context.User
                            select new ExampleRes
                            {
                                userId = us.userId,
                                fuid = us.FirebaseUID,
                                policy = _context.Policy
                                                 .Where(pol=>pol.userId == us.FirebaseUID)
                                                 .Select(new ExampleRes.PoliciesInfo
                                                 {
                                                     policyId = pol.policyId,
                                                     policyType = pol.policyType,
                                                     policyPrice = pol.price,
                                                     coverageType = pol.coverageType
                                                 }).ToList()
                            }).ToList();
