     public double VeryImportantLibraryMethodNumber37(double consumerProvidedGarbage)
     {
        if (consumerProvidedGarbage < 0 || consumerProvidedGarbage > 1)
          throw new ArgumentOutOfRangeException("Here we go again.");
        
        return someOtherNumber * consumerProvidedGarbage;
     }
