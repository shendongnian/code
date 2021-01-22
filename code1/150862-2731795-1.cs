    var coverage = 
                    from insuranceCoverage in context.tblPersonInsuranceCoverages
                    where insuranceCoverage.PersonID == personID
                    select new
                        {
                                insuranceCoverage.PersonInsuranceCoverageID,
                                insuranceCoverage.EffectiveDate,
                                insuranceCoverage.ExpirationDate,
                                insuranceCoverage.Priority,
                                CoverageCategory = insuranceCoverage.insuranceCompany.tblAdminInsuranceCompanyType.TypeName,
                                insuranceCoverage.insuranceCompany.tblBusiness.BusinessName,
                                TypeName = insuranceCoverage.InsuranceTypeID,
                                Address = insuranceCoverage.insuranceCompany.Addresses
                                                                            .Where(a => a.AddressTypeID == 'b')
                                                                            .FirstOrDefault()
                            };
