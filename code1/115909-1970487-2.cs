    HospList list=patient.getHospitalizationList(patientId);
    if (list==null)
    {
       // ... handle missing list ...
    }
    else
    {
      for (HospEntry entry : list)
       //  ... do whatever ...
    }
