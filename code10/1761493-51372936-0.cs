    [HttpPost]
    public string CargarAlumnos()
    {
    	List<Alumno> lstAlumnos = new List<Alumno>();
    	if (Request.Files.Count > 0)
    	{
    		var file = Request.Files[0];
    
    		if (file != null && file.ContentLength > 0)
    		{
    			StreamReader reader = new StreamReader(file.InputStream);
    			
    			while (!reader.EndOfStream) 
    			{ 
    				var line = reader.ReadLine(); 
    				line = line.Replace("<br>", ""); 
    				string[] data = line.Split(','); 
    				
    				if (data != null && data.Count() > 0) 
    				{ 
    					// YOUR DATA IS HERE 
    					Alumno nAlu = new Alumno
    					{
    						numero = Convert.ToInt32(dato[0]),
    						cedula = dato[1],
    						nombre = dato[2],
    						apellido = dato[3]
    					};
    
    					lstAlumnos.Add(nAlu);
    				}
    			}	
    		}
    	}
    }
