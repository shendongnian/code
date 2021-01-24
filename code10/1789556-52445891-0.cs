     mock2
        .Setup(x => x.GetPatientEscalations(
            It.IsAny<string>(), 
            It.IsAny<int>(), //this is an assumption. use desired type here
            It.IsAny<DateTime>(), 
            It.IsAny<DateTime>(), 
            It.IsAny<DataTable>()))
        .Returns((PatientEscalationsDto)null);
