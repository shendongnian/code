	public static string ElapsedTime(DateTime dtEvent)
	{
		TimeSpan TS = DateTime.Now - dtEvent;
	
		int intYears = DateTime.Now.Year - dtEvent.Year;
		int intMonths = DateTime.Now.Month - dtEvent.Month;
		int intDays = DateTime.Now.Day - dtEvent.Day;
		int intHours = DateTime.Now.Hour - dtEvent.Hour;
		int intMinutes = DateTime.Now.Minute - dtEvent.Minute;
		int intSeconds = DateTime.Now.Second - dtEvent.Second;
	
		if (intYears > 0) return String.Format("há {0} {1}", intYears, (intYears == 1) ? "ano" : "anos");
		else if (intMonths > 0) return String.Format("há {0} {1}", intMonths, (intMonths == 1) ? "mês" : "meses");
		else if (intDays > 0) return String.Format("há {0} {1}", intDays, (intDays == 1) ? "dia" : "dias");
		else if (intHours > 0) return String.Format("há {0} {1}", intHours, (intHours == 1) ? "hora" : "horas");
		else if (intMinutes > 0) return String.Format("há {0} {1}", intMinutes, (intMinutes == 1) ? "minuto" : "minutos");
		else if (intSeconds > 0) return String.Format("há {0} {1}", intSeconds, (intSeconds == 1) ? "segundo" : "segundos");
		else
		{
			return String.Format("em {0} às {1}", dtEvent.ToShortDateString(), dtEvent.ToShortTimeString());
		}
	}
