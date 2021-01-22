        public class MySerialPort:SerialPort
        {
            protected override void Dispose(bool disposing)
            {
                try
                {
                    base.Dispose(disposing);
                }
                catch (Exception exc )
                {                    
                    if (disposing)
                    {
                        //Log the error
                    }
                }
                
            }
        }
