         UserConfiguration = (loadConfiguration && c.Configuration != null) ? new ApplicationConfiguration
         {
              ID = c.Configuration.ID,
              MonthlyAccountPrice = c.Configuration.MonthlyAccountPrice,
              TrialAccountDays = c.Configuration.TrialAccountDays,
              VAT = c.Configuration.VAT,
              DateCreated = c.Configuration.DateCreated
          } : null
