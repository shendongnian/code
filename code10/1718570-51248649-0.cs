            /// <summary>
        /// Find the Photoshop instance and return it
        /// </summary>
        /// <returns>Photoshop Application COM object</returns>
        [STAThread]
        public static Photoshop.Application SetPhotoshop()
        {
            Type photoshopType = Type.GetTypeFromProgID("Photoshop.Application");
            Photoshop.Application psApp = null;
            object obj = Activator.CreateInstance(photoshopType);
            if (photoshopType != null)
            {
                try
                {
                    psApp = (Photoshop.Application)obj;
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.ToString());
                    return null;
                }
            }
            return psApp;
        }
