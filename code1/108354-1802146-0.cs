    public  class Doctor
    {
            public Doctor()
            {
                // doctor initialization - iterate through all patients
                foreach(patient in patList) 
                {
                     // for each patient register local method as event handler
                     // of the AbnormalPulseRaised event.
                     patient.AbnormalPulseRaised += 
                        new PulseNotifier(this.OnAbnormalPulseRaised);
                   
                }
            }
            public void OnAbnormalPulseRaised(Patient p)
            {
                Console.WriteLine("Patient Id :{0},Heart beat {1}",
                p.PatientID, p.HeartBeat);
            }
      
            public string Name
            {
                get;
                set;
            }
    }
    public   class Patient
    {
            public event PulseNotifier AbnormalPulseRaised;
            static Random rnd = new Random(); 
    
            public Patient()
            {
            }
            public string PatientID
            {
                get;
                set;
            }
    
            public int HeartBeat
            {
                get;
                set;
            }
    
            public void HeartBeatSimulation(List<Patient> patList)
            {
                foreach(Patient p in patList)
                {
                    if (p.HeartBeat > 120)
                    {
                        if (AbnormalPulseRaised != null)
                        {
                            AbnormalPulseRaised(p);
                        }
                    }
                }
             }
        }
