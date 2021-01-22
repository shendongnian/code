        [Test]
        [TestCase("1000")]
        public void ListSubOrganizationsFiltersAwayDeprecatedOrganizations(string pasId)
        {
            var request = ListOrganizations2GRequest.Initialize(pasId);
            var unitsNotFiltered = OrganizationWSAgent.ListOrganizations2G(PasSystemTestProvider.PasSystemWhenTesting, request);
            request.ValidPeriod = new ListOrganizations2GRequestValidPeriod { ValidFrom = new DateTime(2015, 3, 24), ValidFromSpecified = true };
            
            var unitsFiltered = OrganizationWSAgent.ListOrganizations2G(PasSystemTestProvider.PasSystemWhenTesting, request);
            Assert.IsNotNull(unitsNotFiltered);
            Assert.IsNotNull(unitsFiltered);
            CollectionAssert.IsNotEmpty(unitsFiltered.Organization);
            CollectionAssert.IsNotEmpty(unitsNotFiltered.Organization);
            int[] unitIdsFiltered = unitsFiltered.Organization[0].SubsidiaryOrganization.Select(so => so.Id).ToArray();
            var filteredUnits = unitsNotFiltered.Organization[0].SubsidiaryOrganization
                .Where(u => !unitIdsFiltered.Contains(u.Id)).ToList();
            Assert.IsNotNull(filteredUnits);
            CollectionAssert.IsNotEmpty(filteredUnits);
            Assert.That(filteredUnits, Has.All.Matches<OrganizationHierarchySimpleType>(ohs => (!IsValidPeriodForToday(ohs)))); 
        }
        private static bool IsValidPeriodForToday(OrganizationHierarchySimpleType ohs)
        {
            return ohs.ValidPeriod != null
                   && ohs.ValidPeriod.ValidFrom <= DateTime.Now && ohs.ValidPeriod.ValidTo >= DateTime.Now;
        }
