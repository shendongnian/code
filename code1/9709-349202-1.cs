            // We should have been disposed using Dispose().
            Debug.WriteLine("Finalize being called, should have been disposed");
        
            if (this.ComObject != null)
            {
                Debug.WriteLine(string.Format("ComObject was not null:{0}, name:{1}.", this.ComObject, this.ComObjectName));
            }
        
            //Debug.Assert(false);
        }
