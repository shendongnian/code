            // Inside your timer event.
            using (System.IO.FileStream fs = new System.IO.FileStream("yourfile.log", 
                   System.IO.FileMode.Open, System.IO.FileAccess.Read, 
                   System.IO.FileShare.ReadWrite))
            {
                // use fs to read from file as required
            }
