      // Morphine is narcotic only
      MedicationTags morphine = MedicationTags.Narcotic; 
      // LSD is both narcotic and psychotropic
      MedicationTags lsd = MedicationTags.Narcotic | MedicationTags.Psychotropic; 
      // Good old aspirin is neither narcotic nor psychotropic
      MedicationTags aspirin = MedicationTags.None; 
