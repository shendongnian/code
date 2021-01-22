        [Test]
        public void EmptyNameAndOfficialIdDoesNotThrow()
        {
            var patientDecryptingRule = new PatientDecryptingRule();
            object[] reservation = new object[]
            {
                new Operation
                {
                    Status = (int) OperationStatusDataContract.Reservation,
                    Patient = new Patient
                    {
                        Name = null,
                        OfficialId = null,
                        IsPatientEncrypted = true
                    }
                }
            };
            var relevantConstructor = typeof(ObjectMaterializedEventArgs).GetConstructors(
                BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
            ObjectMaterializedEventArgs objectMaterializedEventArgs =
                (ObjectMaterializedEventArgs) relevantConstructor?.Invoke(reservation);
            patientDecryptingRule.ModifyObjectMaterialized(objectMaterializedEventArgs);
        }
