    public string ObtenerNumeroMes(string NombreMes){
           
           string NumeroMes;   
           switch(NombreMes) {
            
            case ("ENERO") :
                NumeroMes = "01";
                return NumeroMes;
                
            case ("FEBRERO") :
                NumeroMes = "02";
                return NumeroMes;
                
            case ("MARZO") :
                NumeroMes = "03";
                return NumeroMes;
                
            case ("ABRIL") :
                NumeroMes = "04";
                return NumeroMes;
                
            case ("MAYO") :
                NumeroMes = "05";
                return NumeroMes;
                
            case ("JUNIO") :
                NumeroMes = "06";
                return NumeroMes;
                
            case ("JULIO") :
                NumeroMes = "07";
                return NumeroMes;
                
            case ("AGOSTO") :
                NumeroMes = "08";
                return NumeroMes;
                
            case ("SEPTIEMBRE") :
                NumeroMes = "09";
                return NumeroMes;
                
            case ("OCTUBRE") :
                NumeroMes = "10";
                return NumeroMes;
                
            case ("NOVIEMBRE") :
                NumeroMes = "11";
                return NumeroMes;
                
            case ("DICIEMBRE") :
                NumeroMes = "12";
                return NumeroMes;
                
                default:
                Console.WriteLine("Error");
                return "ERROR";
            }
       }
