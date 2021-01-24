	DateTime myDate;
	this.Dispatcher.Invoke(() =>
	{
		// Your UI code here
		SecondLog.Opacity = 1;
		myDate = PickFecha.SelectedDate.Value.Date;
	});
	
    List<Reporte> Reportes = await Task.Run(() => db_data.TraerReportes(Environment.MachineName, myDate.ToShortDateString()));
    if (Reportes.Count != 0)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Nombre del Proceso");
        dt.Columns.Add("Tiempo Activo");
        dt.Columns.Add("Hora del Ultimo Reporte");
        foreach (Reporte R in Reportes)
        {
            TimeSpan a = TimeSpan.FromSeconds(R.TiempoActivo);
            var Columna = dt.NewRow();
            Columna["t1"] = R.NombreProceso;
            Columna["t2"] = a.ToString(@"hh\:mm\:ss");
            Columna["t3"] = R.Fecha;
            dt.Rows.Add(Columna);
        }
		
		this.Dispatcher.Invoke(() =>
		{
			GridReportes.DataContext = dt.DefaultView;
		});			
    }
