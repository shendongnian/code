    public class TestRefMedicalSpecialty {
        private IRepository<RefMedicalSpecialty> mockRefMedicalRepo;
    
        public TestRefMedicalSpecialty() {
            var mockRefMedicalSpecialties = new List<RefMedicalSpecialty>
            {
                new RefMedicalSpecialty {Code = "10000", Description = "Medical Specialty1"},
                new RefMedicalSpecialty {Code = "10001", Description = "Medical Specialty2"},
                new RefMedicalSpecialty {Code = "10002", Description = "Medical Specialty3"}
            };
    
            var mock = new Mock<IRepository<RefMedicalSpecialty>>();
    
            mock.Setup(_ => _.GetAll()).Returns(mockRefMedicalSpecialties);
    
            this.mockRefMedicalRepo = mock.Object;
        }
    
        [Fact]
        public void GetAll_Returns_Data() {
    
            //pass the mocked repo into a dependent class and 
            //exercise test that relies on calling GetAll
    
        }
    }
