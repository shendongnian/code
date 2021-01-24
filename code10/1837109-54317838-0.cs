    List<RiskDTO> results = actions
        .Select(ra => new RiskDTO
        {
            CurrentControlled = ra.RiskActions.Any(m => m.ActionCompleteDate == null))
                ? TerminologyFactor.Parse("{Current}",TerminologyFactor.RMMonitor)
                : TerminologyFactor.Parse("{Controlled}",TerminologyFactor.RMMonitor)
        }
