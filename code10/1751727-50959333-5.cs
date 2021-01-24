    var policies = (from pol in _context.Policy
                    group pol by pol.userId into uid
                    where uid.Count() > 0
                    join us in _context.User
                    on uid.Key equals us.FirebaseUID
                    select new ExampleRes
                    {
                        userId = us.userId,
                        fuid = us.FirebaseUID,
                        policy = (from pol in _context.Policy
                                  where pol.userId == uid.Key
                                  select new ExampleRes.PoliciesInfo
                                  {
                                      policyId = pol.policyId,
                                      policyType = pol.policyType,
                                      policyPrice = pol.price,
                                      coverageType = pol.coverageType
                                  }).ToList()
                    }).ToList();
