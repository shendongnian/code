    DateTime fechaInicio = new DateTime(año, mes, 1);
    DateTime fechaFin = fechaInicio.AddMonths(1);
    int diasHastaFinMes = 0;
    while (esFinDeSemana(fechaInicio))
        fechaInicio = fechaInicio.AddDays(1);
    for (DateTime fecha = fechaInicio; fecha < fechaFin; fecha = fecha.AddDays(7))
    {
        diasHastaFinMes = DateTime.DaysInMonth(fecha.Year, fecha.Month) - fecha.Day;
        printWeeks(fecha, fecha.AddDays(Math.Min(4, diasHastaFinMes)));
    }
