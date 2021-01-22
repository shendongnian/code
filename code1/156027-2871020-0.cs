    private ObjectWithServiceDependency CreateObjectUnderTest(){
         //Here you would inject your Service dependency with the above answer from Darin
         //i.e.
         var mockService= MockRepository.GenerateMock<Service>(new object[] {new Command[0] });
         var objectUnderTest = new ObjectWithServiceDependency(mockService);
         return objectUnderTest;
    }
