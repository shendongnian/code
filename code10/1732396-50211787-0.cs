    public void GetAllPatients()
    {
        IsFetchingData = true;
        try
        {
            var resultPatients =         JsonConvert.DeserializeObject<ObservableCollection<PatientViewModel>>(testJson, jsonSerializerSettings);
            
            Patients.Clear(); 
            foreach (var patient in resultPatients)
                Patients.Add(patient);
        }
        catch(Exception e)
        {
            Console.WriteLine("*****ERROR kon API niet ophalen");
            Console.WriteLine(e.Message);
        }
        finally
        {
            IsFetchingData = false;
        }
    }
