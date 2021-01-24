    class Program
    {
        static void Main(string[] args)
        {
            // Create a new list of patients to store your values
            List<Patient> patients = new List<Patient>();
            // Get user input and store them as variables
            Console.WriteLine("Enter the patients name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the patients date of birth: ");
            string dob = Console.ReadLine();
            Console.WriteLine("Enter the patients age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the patients ailment(s): ");
            string ailments = Console.ReadLine();
            Console.WriteLine("Enter the patients medication(s): ");
            string meds = Console.ReadLine();
            Console.WriteLine(); // Empty line
            // Add the given input to the list of patients
            patients.Add(new Patient { patientName = name, patientDOB = dob, patientAilments = ailments, patientMeds = meds, patientAGE = age });
            // Print patients to console output
            foreach (var patient in patients)
            {
                Console.WriteLine("Patients name = {0}", patient.patientName);
                Console.WriteLine("Patients date of birth = {0}", patient.patientDOB);
                Console.WriteLine("Patients age = {0}", patient.patientAGE);
                Console.WriteLine("Patients ailment(s) = {0}", patient.patientAilments);
                Console.WriteLine("Patients medication(s) = {0}", patient.patientMeds);
            }
        }
    }
    class Patient
    {
        public string patientName { get; set; }
        public string patientDOB { get; set; }
        public string patientAilments { get; set; }
        public string patientMeds { get; set; }
        public int patientAGE { get; set; }
    }
