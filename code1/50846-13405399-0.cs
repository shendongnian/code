		[Test()]
		public void Search_Apartment_With_Spesific_Address()
		{
			//ARRANGE
			var repositoryMock = MockRepository.GenerateMock<IApartmentRepository>();
			var notificationMock = MockRepository.GenerateMock<INotificationService>();
			var service = new ApartmentService(repositoryMock, notificationMock);
			var apartment = new List<Apartment> {new Apartment {Address = "Elm Street 2"}}.AsQueryable();
			
			Expression<Func<Apartment, bool>> testPredicate = a => a.Address == "Elm Street 2";
			repositoryMock.Stub(x => x.Find(testPredicate)).Return(apartment);
			//ACT
			service.Find(testPredicate);
			//ASSERT
			repositoryMock.AssertWasCalled(x => x.Find(testPredicate));
		}
