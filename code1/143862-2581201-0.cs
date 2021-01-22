    static void Main(string[] args)
    {
       PatientPrescriptionsEntity[] ppe = new PatientPrescriptionsEntity[] {};
       Array.Sort<PatientPrescriptionsEntity>(ppe, (p1, p2) => 
           p1.MedicationStartDate.Value.CompareTo(p2.MedicationStartDate.Value));
    }
    ...
    class PatientPrescriptionsEntity
    {
       public DateTime? MedicationStartDate;
    }
