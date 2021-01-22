    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 8)]
    public class ModelSettings:IDisposable
    {
        #region Variables
        public string Directory;
        public IntPtr Q;
        public IntPtr Refl;
        public IntPtr ReflError;
        public IntPtr QError;
        public int QPoints;
        public double SubSLD;
          public double SurflayerSLD;
            public double SupSLD;
             public int Boxes;
             public double SurflayerAbs;
             public double SubAbs;
           public double SupAbs;
            public double Wavelength;
             public bool UseAbs;
             public double SupOffset;
         public double Percerror;
           public bool Forcenorm;
             public double Forcesig;
             public bool Debug;
             public bool ForceXR;
        public int Resolution;
        public double Totallength;
        public double Surflayerlength;
        public bool ImpNorm;
        public int FitFunc;
        public double ParamTemp;
        public string version = "0.0.0";
        [XmlIgnoreAttribute] private bool disposed = false;
    #endregion
        public ModelSettings()
        { }
        ~ModelSettings()
        {
            Dispose(false);
        }
       
        #region Public Methods
        public void SetArrays(double[] iQ, double[] iR, double[] iRerr, double[] iQerr)
        {
            //Blank our arrays if they hold data
            if (Q == IntPtr.Zero)
                ReleaseMemory();
            int size = Marshal.SizeOf(iQ[0]) * iQ.Length;
                try
                {
                    QPoints = iQ.Length;
                    Q = Marshal.AllocHGlobal(size);
                    Refl = Marshal.AllocHGlobal(size);
                    ReflError = Marshal.AllocHGlobal(size);
                    if (iQerr != null)
                        QError = Marshal.AllocHGlobal(size);
                    else
                        QError = IntPtr.Zero;
                    Marshal.Copy(iQ, 0, Q, iQ.Length);
                    Marshal.Copy(iR, 0, Refl, iR.Length);
                    Marshal.Copy(iRerr, 0, ReflError, iRerr.Length);
                    if (iQerr != null)
                        Marshal.Copy(iQerr, 0, QError, iQerr.Length);
                }
                catch (Exception ex)
                {
                   //error handling
                }
        }
        #endregion
        #region IDisposable Members
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                // Call the appropriate methods to clean up
                // unmanaged resources here.
                // If disposing is false,
                // only the following code is executed.
                ReleaseMemory();
                // Note disposing has been done.
                disposed = true;
            }
        }
        private void ReleaseMemory()
        {
            if (Q != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(Q);
                    Marshal.FreeHGlobal(Refl);
                    Marshal.FreeHGlobal(ReflError);
                    if (QError != IntPtr.Zero)
                        Marshal.FreeHGlobal(QError);
                }
        }
        #endregion
    }
