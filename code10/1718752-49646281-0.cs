        static void Main(string[] args)
        {
            string json = JsonConvert.SerializeObject(new[] 
            {
                new
                {
                    guardian_id = "1453",
                    guardian_name = "Foo Bar",
                    patient_id = "938",
                    patient_name = "Bar Foo",
                }
            });
            Guardian[] guardians = JsonConvert.DeserializeObject<Guardian[]>(json);
            Patient[] patients = JsonConvert.DeserializeObject<Patient[]>(json);
        }
