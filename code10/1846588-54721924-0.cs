      using (var context = IntegrationTestEnvironment.Setup())
      {
          User bobbyUserDo = new User();
          Profile bobbyPatientDo = new Patient(bobbyUserDo, "bobbyPatient@hotmail.com");
          var bobbyUserDb = await context.UserRepository.AddOrUpdateAsync(bobbyUserDo);
          bobbyUserDb.Should().NotBeNull();
          bobbyUserDb.Id.Should().BeGreaterThan(0);
          bobbyUserDb.Profiles.Should().HaveCount(1);
          bobbyUserDb.Profiles.First().Id.Should().BeGreaterThan(0);
      }
