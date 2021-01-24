    public class EmailJob : IJob
        {
            public Task Execute(IJobExecutionContext context) 
            {
                JobKey key = context.JobDetail.Key;
                JobDataMap dataMap = context.JobDetail.JobDataMap;
    
                string UserName = string.Empty;
                string List_Emails = dataMap.GetString("Email_List");
    
                var correo1 = new MailAddress("test@hotmail.com"); //Colocar el correo principal de salida
                string contrasegna = "PASSWORD"; //Contraseña del Correo de salida
    
                //Correos a los que se debe enviar la información
                var correo2 = new MailAddress(List_Emails);
    
                //El host correspondiente
                string host = "smtp-mail.outlook.com";
    
                //Título y cuerpo del mensaje.
                string subject = "Prueba del uso de Quartz";
                string body = "Se realiza una prueba con Quartz " + DateTime.Now + " .Finalmente se logra la incorporación de esta librería";
                //
    
                using (var message1 = new MailMessage(correo1, correo2))
                {
                    message1.Subject = subject;
                    message1.Body = body;
                    using (SmtpClient client = new SmtpClient
                    {
                        Host = host,
                        Port = 587,
                        EnableSsl = true,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(correo1.Address, contrasegna)
                    })
                    {
                        client.Send(message1);
                    }
                }
    
                return Task.CompletedTask;
            }
        }
